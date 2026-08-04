using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

//using System.Data;
using System;



#if UNITY_ANDROID
using Unity.Notifications.Android; // solo se carga esto si se ejecuta en android
#endif

public class ControladorNotificaciones : MonoBehaviour
{
    public void InvocarNotificaciones(float retraso = 0.0f)
    {
        DateTime fechaActiva = DateTime.Now.AddSeconds(retraso);
#if UNITY_ANDROID
        CrearNotificacion(fechaActiva);
#endif
    }

    #if UNITY_ANDROID
    private const string idCanalNot = "canaNotificacion";

    private void Start() => StartCoroutine(PermisoNotificaciones());

    public void CrearNotificacion( DateTime fecha)
    {
        AndroidNotificationChannel canalDeNotificacionesAndroid = new AndroidNotificationChannel {
            Id = idCanalNot,
            Name = "CanalNotificacion",
            Description = "Canal Para Notificaciones",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(canalDeNotificacionesAndroid);

        AndroidNotification androidNotification = new AndroidNotification { 
            Title = "Guardado",
            Text = "Se ha guardado su partida actual",
            SmallIcon = "defaul",
            LargeIcon = "defaul",
            FireTime = fecha
        };

        AndroidNotificationCenter.SendNotification(androidNotification, idCanalNot); // se envia la notificacion
            
    }

    IEnumerator PermisoNotificaciones()
    {
        var requedt = new PermissionRequest();
        while (requedt.Status == PermissionStatus.RequestPending) { yield return null; }
    }

     

#endif
}
