namespace Questioner.Api.Contracts.Messages
{
    public static class Entity
    {
        public const string USER_REGISTRING = "Registrando Usuario: Email {0}";
        public const string USER_REGISTRING_OK = "Usuario Registrado Satisfactoriamente {0}";
        public const string USER_LOGIN = "Login Usuario: Email {0}";
        public const string USER_LOGIN_OK = "Login Usuario Satisfactoriamente!";
        public const string USER_GETALL = "Consultando todos los Usuarios";
        public const string USER_GET_OK = "Retornando Usuario: {0}";
        public const string USER_GETALL_OK = "Retornando {0} Usuarios";
        public const string USER_NOFOUND_OK = "No se encontraron Usuarios";
        public const string USER_UPDATEROLE = "Actualizando Rol de Usuario {0}, Nuevo Rol {1}";
        public const string USER_UPDATEROLE_OK = "Rol de Usuario Actualizado Satisfactoriamente";
        public const string USER_DELETING = "Eliminando Usuario: Id {0}";
        public const string USER_DELETING_OK = "Usuario Eliminado Satisfactoriamente: Id {0}";
        public const string USER_ACTIVATING = "Activando Usuario Eliminado Id {0}";
        public const string USER_ACTIVATE_OK = "Usuario Activado Satisfactoriamente: Id {0}";
        public const string PASSWORD_CHANGE = "Cambiando Contraseña de Usuario: Id {0}";
        public const string PASSWORD_CHANGE_OK = "Contraseña de Usuario Cambiada Satisfactoriamente";
        public const string USER_LOGOUT_OK = "Logout Usuario Satisfactoriamente!";

        public const string ERROR_INVALID_USER = "Usuario no valido";
        public const string ERROR_CREATE_USER = "Error al Crear Usuario";
    }
}
