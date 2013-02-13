using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Ouya.Console.Api
{
    public abstract partial class CancelIgnoringOuyaResponseListener : global::Java.Lang.Object, global::Ouya.Console.Api.IOuyaResponseListener
    {
        public abstract void OnSuccess(global::Java.Lang.Object result);
    }

    internal partial class CancelIgnoringOuyaResponseListenerInvoker : CancelIgnoringOuyaResponseListener, global::Ouya.Console.Api.IOuyaResponseListener
    {
        static IntPtr id_onSuccess_ILjava_lang_Object_;
        public override void OnSuccess(global::Java.Lang.Object result)
        {
            if (id_onSuccess_ILjava_lang_Object_ == IntPtr.Zero)
                id_onSuccess_ILjava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onSuccess", "(ILjava/lang/String;Landroid/os/Bundle;)V");
            JNIEnv.CallVoidMethod(Handle, id_onSuccess_ILjava_lang_Object_, new JValue(result));
        }
    }

    [global::Android.Runtime.Register("mono/tv/ouya/console/api/CancelIgnoringOuyaResponseListenerImplementor", DoNotGenerateAcw = true)]
    public sealed class CancelIgnoringOuyaResponseListenerImplementor : CancelIgnoringOuyaResponseListener
    {

        object sender;

        public CancelIgnoringOuyaResponseListenerImplementor(object sender)
            : base(global::Android.Runtime.JNIEnv.CreateInstance("mono/tv/ouya/console/api/OuyaResponseListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
        {
            this.sender = sender;
        }

#pragma warning disable 0649
        public EventHandler OnCancelHandler;
#pragma warning restore 0649

        [Register("onCancel", "()V", "GetOnCancelHandler:Ouya.Console.Api.IOuyaResponseListenerInvoker, Ouya.Console.Api")]
        public override void OnCancel()
        {
            if (OnCancelHandler != null)
                OnCancelHandler(sender, new EventArgs());
        }

#pragma warning disable 0649
        public EventHandler<FailureEventArgs> OnFailureHandler;
#pragma warning restore 0649

        [Register("onFailure", "(ILjava/lang/String;Landroid/os/Bundle;)V", "GetOnFailure_ILjava_lang_String_Landroid_os_Bundle_Handler:Ouya.Console.Api.IOuyaResponseListenerInvoker, Ouya.Console.Api")]
        public override void OnFailure(int errorCode, string errorMessage, global::Android.OS.Bundle optionalData)
        {
            if (OnFailureHandler != null)
                OnFailureHandler(sender, new FailureEventArgs(errorCode, errorMessage, optionalData));
        }
#pragma warning disable 0649
        public EventHandler<SuccessEventArgs> OnSuccessHandler;
#pragma warning restore 0649

        [Register("onSuccess", "(Ljava/lang/Object;)V", "GetOnSuccess_Ljava_lang_Object_Handler:Ouya.Console.Api.IOuyaResponseListenerInvoker, Ouya.Console.Api")]
        public override void OnSuccess(global::Java.Lang.Object result)
        {
            if (OnSuccessHandler != null)
                OnSuccessHandler(sender, new SuccessEventArgs(result));
        }
    }
}