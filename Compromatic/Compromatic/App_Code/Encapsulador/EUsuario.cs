using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EUsuario
/// </summary>
public class EUsuario
{
	public EUsuario()
	{
	}

    private int idUsr;

    public int IdUsr
    {
        get { return idUsr; }
        set { idUsr = value; }
    }
    private String nomUsr;
   

    public String NomUsr
    {
        get { return nomUsr; }
        set { nomUsr = value; }
    }

    private String apelUsr;

    public String ApelUsr
    {
        get { return apelUsr; }
        set { apelUsr = value; }
    }

    private String telUsr;

    public String TelUsr
    {
        get { return telUsr; }
        set { telUsr = value; }
    }

    private String correoUsr;

    public String CorreoUsr
    {
        get { return correoUsr; }
        set { correoUsr = value; }
    }

    private String passUsr;

    public String PassUsr
    {
        get { return passUsr; }
        set { passUsr = value; }
    }

    private String ccUsr;

    public String CcUsr
    {
        get { return ccUsr; }
        set { ccUsr = value; }
    }

    private String dirUsr;

    public String DirUsr
    {
        get { return dirUsr; }
        set { dirUsr = value; }
    }
    private String nomArch;

    public String NomArch
    {
        get { return nomArch; }
        set { nomArch = value; }
    }

    private String rutaArch;

    public String RutaArch
    {
        get { return rutaArch; }
        set { rutaArch = value; }
    }

    private int estUsr;

    public int EstUsr
    {
        get { return estUsr; }
        set { estUsr = value; }
    }
}