using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace ServiceQuestion {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //Session[ "login" ] = 1;
            if ( !IsPostBack ) {
                if ( Session[ "ServiceCode" ] != null && Session[ "EventID" ] != null ) {
                    ServiceSelect.Visible = false;
                    ServiceSelected.Visible = true;
                    string tmpServicecode = Session[ "ServiceCode" ].ToString ( );
                    string tmpEventID = Session[ "EventID" ].ToString ( );
                    Session.Clear ( );
                    Session[ "ServiceCode" ] = tmpServicecode;
                    Session[ "EventID" ] = tmpEventID;
                    /******** กิจกรรม Wurth *********/
                    if ( tmpEventID == "3" ) {
                        wurth.Visible = true;

                        a.Visible = true;
                        b.Visible = false;
                    }/******** กิจกรรมศาลาสาระ *********/ 
                    else {
                        SalaLogo.Visible = true;
                        a.Visible = true;
                        b.Visible = false;
                    }
                } else {
                    ServiceSelect.Visible = true;
                    ServiceSelected.Visible = false;
                    Select_Event ( );
                }
                //Session.Clear ( );
            } else { }
        }

        protected void Select_Event( ) {
            Question qt = new Question ( );
            EventDropdown.DataSource = qt.GetEvent ( );
            EventDropdown.DataValueField = "EventID";
            EventDropdown.DataTextField = "EventName";
            EventDropdown.DataBind ( );
            EventDropdown.Items.Insert ( 0, new ListItem ( "เลือกกิจกรรม", "none" ) );
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if ( Session[ "EventID" ].ToString ( ) == "3" ) {
                if ( Tel.Text.Length < 10 ) {
                    string Next5 = "Swal.fire({type: 'error',title: 'กรอกเบอร์โทรไม่ครบ'})";
                    ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", Next5, true );
                } else { 
                    Session[ "License" ] = LicensePlate.Text;
                    Session[ "Tel" ] = Tel.Text;
                    Session[ "UType" ] = type.SelectedValue;

                    Response.Redirect ( @"~/question.aspx" );
                }
            }else{
                if ( type.SelectedValue == "" ) {
                    string error = "alert('กรุณาเลือก กลุ่มลูกค้า')";
                    ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", error, true );
                } else {
                    if ( Tel.Text.Length < 10 ) {
                        string Next5 = "Swal.fire({type: 'error',title: 'กรอกเบอร์โทรไม่ครบ'})";
                        ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", Next5, true );
                    } else { 

                        Session[ "License" ] = LicensePlate.Text;
                        Session[ "Tel" ] = Tel.Text;
                        
                        Response.Redirect ( @"~/question.aspx" );
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e) {
            if ( ServiceCode.SelectedValue == "none" ) {
                string Next5 = "Swal.fire({type: 'error',title: 'กรุณาสาขา'})";
                ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", Next5, true );
            } else if ( EventDropdown.SelectedValue == "none" ) {
                string Next5 = "Swal.fire({type: 'error',title: 'กรุณากิจกรรม'})";
                ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", Next5, true );
            } else {
                Session[ "ServiceCode" ] = ServiceCode.SelectedValue.ToString ( );
                Session[ "EventID" ] = EventDropdown.SelectedValue.ToString ( );
                Response.Redirect ( @"~/Default.aspx" );
            }
            
        }

        protected void next_Click(object sender, ImageClickEventArgs e) {
            if ( type.SelectedValue == "" ) {
                string error = "alert('กรุณาเลือก กลุ่มลูกค้า')";
                ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", error, true );
            } else {
                Session[ "UType" ] = type.SelectedValue.ToString ( );
                a.Visible = false;
                b.Visible = true;
            }
        }

        [WebMethod] 
        public static List<string> SearchLiecnsePlace(string prefixText) {

            user user = new user ( );
            user.LicensePlate = prefixText;
            DataTable dt = user.Select_LicensePlate ( );

            List<string> LicensePlate = new List<string> ( );
            foreach ( DataRow dr in dt.Rows ) {
                LicensePlate.Add ( dr["LicencePlate"].ToString() );
            }
            return LicensePlate;
        }
    }
}
