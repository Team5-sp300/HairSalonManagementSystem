package md5b76358c62d0ed5b54e301eee72c3d151;


public class ClientInformatin
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("HHmobileApp.ClientInformatin, HHmobileApp", ClientInformatin.class, __md_methods);
	}


	public ClientInformatin ()
	{
		super ();
		if (getClass () == ClientInformatin.class)
			mono.android.TypeManager.Activate ("HHmobileApp.ClientInformatin, HHmobileApp", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
