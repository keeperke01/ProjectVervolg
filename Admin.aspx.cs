﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    BLLUser BLLUser = new BLLUser();
    List<User> lijstUsers= new List<User>();
    List<string> lijstnamen = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        lijstUsers = BLLUser.selectGeenAdmin();
        string gebruiker = "";

        

        foreach (User row in lijstUsers)
        {
            lijstnamen.Add(row.gebruikersnaam);

        }
        

         if (!IsPostBack)
        {
            
            ddlGebruikers.DataSource = lijstnamen;
            ddlGebruikers.DataBind();
            
        }
         else
         {
             gebruiker = ddlGebruikers.SelectedItem.Text;
             Session.Add("gebruiker", gebruiker);
         }
        
    }
    protected void btnAdmin_Click(object sender, EventArgs e)
    {

        string gebruiker = Session["gebruiker"].ToString();
            BLLUser.updateUser(gebruiker);
            Session.Add("feedback", "De user is admin geworden.");
            Response.Redirect("~/Home.aspx");
        
    }
    protected void btnTerug_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    }
}