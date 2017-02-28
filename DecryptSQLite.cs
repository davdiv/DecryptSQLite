using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace DecryptSQLite
{
	public class DecryptSQLite
	{
		static void Main ()
		{
			try {
				start ();
			} catch (Exception e) {
				MessageBox.Show ("Une erreur inattendue s'est produite:\n" + e, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		static void start ()
		{
			String sourceFile = null;
			String destinationFile = null;
			String sourcePassword = "password";
			String destinationPassword = "";

			const string FILTER = "Base de données (*.db3)|*.db3|Tous les fichiers (*.*)|*.*";
			FileDialog sourceFileSelection = new OpenFileDialog ();
			sourceFileSelection.Filter = FILTER;
			sourceFileSelection.Title = "Ouvrir la base de données";
			if (sourceFileSelection.ShowDialog () != DialogResult.OK) {
				return;
			}
			sourceFile = sourceFileSelection.FileName;

			FileDialog destinationFileSelection = new SaveFileDialog ();
			destinationFileSelection.Filter = FILTER;
			destinationFileSelection.DefaultExt = "db3";
			destinationFileSelection.FileName = Path.GetDirectoryName (sourceFile) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension (sourceFile) + "-decrypte.db3";
			destinationFileSelection.Title = "Enregistrer la base de données";
			if (destinationFileSelection.ShowDialog () != DialogResult.OK) {
				return;
			}
			destinationFile = destinationFileSelection.FileName;

			sourcePassword = Interaction.InputBox ("Mot de passe pour\n" + sourceFile, "Ancien mot de passe", sourcePassword);
			destinationPassword = Interaction.InputBox ("Mot de passe pour\n" + destinationFile, "Nouveau mot de passe", destinationPassword);

			const string CONNECTION_STRING = "URI=file:{0};Version=3;Password={1};";
			const string CONNECTION_STRING_NO_PASSWORD = "URI=file:{0};Version=3;";
			if (!sourceFile.Equals (destinationFile)) {
				File.Copy (sourceFile, destinationFile);
			}
			String connectionString = sourcePassword.Length > 0 ?
			                                        String.Format (CONNECTION_STRING, destinationFile, sourcePassword) :
			                                        String.Format (CONNECTION_STRING_NO_PASSWORD, destinationFile);

			try {
				SQLiteConnection connection = new SQLiteConnection (connectionString);
				connection.Open ();
				try {
					connection.ChangePassword (destinationPassword);
					connection.Close ();
					MessageBox.Show ("Mot de passe changé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
				} catch (Exception e) {
					MessageBox.Show ("Erreur lors du changement de mot de passe:\n" + e, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} catch (Exception e) {
				MessageBox.Show ("Erreur lors de l'ouverture de la base de données:\n" + e, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
