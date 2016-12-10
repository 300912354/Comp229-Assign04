using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Comp229_Assign04.Models;
using System.IO;

namespace Comp229_Assign04
{
    public partial class Contact : Page

    {
        //public partial class Model : System.Web.UI.Page
        //{
        private Models.Model _Model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //utton2.Text=thisPlace.Button2;
            }
            try
            {
                var name = Request.QueryString["name"];
                var faction = Request.QueryString["faction"];
                if (string.IsNullOrEmpty(name))
                {
                    Response.Redirect("~/Home_Page.aspx");
                    return;
                }
                _Model = Global.Models.FirstOrDefault(tModel => tModel.name == name && tModel.faction == faction);
                SetBindings();
                name_row.Visible = true;
                row1.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
        private void SetBindings()
        {


            modelImg.ImageUrl = _Model.imageUrl;
            nameLabel.Text = _Model.name;
            factionLabel.Text = _Model.faction;
            rankLabel.Text = _Model.rank.ToString();
            baseLabel.Text = _Model._base + "mm";
            sizeLabel.Text = _Model.size.ToString();
            deploymentzoneLabel.Text = _Model.deploymentZone;


            traitsRepeater.DataSource = _Model.traits;    
            traitsRepeater.DataBind();


            typeRepeater.DataSource = _Model.types; 
            typeRepeater.DataBind();

            defenceChartRepeater.DataSource = _Model.defenseChart;
            defenceChartRepeater.DataBind();


            mobilityLabel.Text = _Model.mobility.ToString();
            willpowerLabel.Text = _Model.willpower.ToString();
            resilienceLabel.Text = _Model.resiliance.ToString();
            woundsLabel.Text = _Model.wounds.ToString();


            actionRepeater.DataSource = _Model.actions;
            actionRepeater.DataBind();

            specialAbilitiesRepeater.DataSource = _Model.specialAbilities;
            specialAbilitiesRepeater.DataBind();

        }

        //protected void UpdateButton_Click(object sender, EventArgs e)

        //{

        //    _Model.name = "new name";
        //    var one = Global.Models;
        //    var two = 2;
        //    Global.UpdateNewJsonFile();

        //}

    //    protected void Button1_Click(object sender, EventArgs e)
    //    {
    ////      var theValue = this.Context.Request[this.TextBox1.ClientID];
    //        Button2.Visible = true;
    //        TextBox1.Text = _Model.name;
    //        //_Model.name = "Sword Strike";
    //        //Response.Redirect("~/Update_Page.aspx");
    //        name_row.Visible = false;
    //        row1.Visible = true;
    //        var one = Global.Models;
    //        var two = 2;
    //      //  Global.UpdateNewJsonFile();
    //       //utton1.Visible = false;
    //    }
        protected void UpdateButton1_Click(object sender, EventArgs e)
        {
            Label4.Visible = false;
            _Model.name = NameTextBox.Text;

            _Model.faction = FactionTextBox.Text;

            _Model.deploymentZone = deploymentZoneTextBox.Text;




            ////////////////////////////////
            //updates json file
            Global.UpdateNewJsonFile();
            //emails file
            Global.EmailJsonFile("comp229f2016@outlook.com", "Mark", Global.ModelsNewJsonFilePath);
            Label4.Visible = true;

        }
    }
}