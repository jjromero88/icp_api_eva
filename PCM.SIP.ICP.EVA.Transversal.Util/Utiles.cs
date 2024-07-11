using System.Globalization;

namespace PCM.SIP.ICP.EVA.Transversal.Util
{
    public static class Utiles
    {

        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1).ToLower();

            return str.ToUpper();
        }

        public static string InicialesAvatar(string nombre, string apellidos)
        {
            string iniciales = $"{nombre[0]}{apellidos[0]}";
            string inicialesMayusculas = iniciales.ToUpper();
            return inicialesMayusculas;
        }

        public static string MessageUpdateSuccess => "La información ha sido actualizada correctamente.";
        public static string MessageSaveSuccess => "La información ha sido registrada correctamente.";
        public static string MessageDeleteSuccess => "La información ha sido eliminada.";

        public static string MessageUserExists(string username) => "El nombre de usuario '" + username + "' ya existe.";

        public static string MessageServerError => "Ocurrió un problema, intentelo nuevamente.";
        public static string MessageModelStateInvalid => "Verifique la información ingresada.";

        public static string MessageFileSaveError(string filename) => "Error: El archivo " + filename + " no pudo ser guardado";
    }
}
