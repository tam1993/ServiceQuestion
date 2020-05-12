using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceQuestion
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                SelectAllQuestion();
                SelectAllReward();
            } else { 
                
            }
        }

        protected DataTable SelectAllQuestion() {
            DataTable dt = new DataTable();
            try {
                Question q = new Question();
                dt = q.GetAllQuestion();
                QuestionGridView.DataSource = dt;
                QuestionGridView.DataBind();
            } catch (Exception) { 
                
            }
            return dt;
        }

        protected DataTable SelectAllReward() {
            DataTable dt = new DataTable();
            try {
                Reward q = new Reward();
                dt = q.GetAllReward();
                RewardGridView.DataSource = dt;
                RewardGridView.DataBind();
            } catch (Exception) {

            }
            return dt;
        }

        protected void QuestionGridView_RowEditing(object sender, GridViewEditEventArgs e) {
            DataTable dt = new DataTable();
            QuestionGridView.EditIndex = e.NewEditIndex;
            dt = SelectAllQuestion();

            //active select servicecode
            DropDownList ServiceEdit = (DropDownList)QuestionGridView.Rows[e.NewEditIndex].FindControl("ServiceEdit");
            ServiceEdit.SelectedValue = dt.Rows[e.NewEditIndex]["QServiceCode"].ToString();

            //focus textbox
            DropDownList TotalEdit = (DropDownList)QuestionGridView.Rows[e.NewEditIndex].FindControl("ServiceEdit");
            TotalEdit.Focus();
        }

        protected void QuestionGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            QuestionGridView.EditIndex = -1;
            SelectAllQuestion();
        }

        protected void QuestionGridView_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            string res = "";
            try {
                Question q = new Question();
                q.QuestionID = int.Parse(QuestionGridView.DataKeys[e.RowIndex]["QID"].ToString());
                DropDownList ServiceEdit = (DropDownList)QuestionGridView.Rows[e.RowIndex].FindControl("ServiceEdit");
                q.ServiceCode = int.Parse(ServiceEdit.SelectedValue.ToString());
                q.UpdateQuestion();

                QuestionGridView.EditIndex = -1;
                SelectAllQuestion();

                res = "Swal.fire({type: 'success',title: 'OK'});$('#nav-question').tab('show');";
                
            } catch (Exception ex) { 
                res = "Swal.fire({type: 'error',title: '"+ex.Message+"'});$('#nav-question').tab('show');";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", res, true);
        }

        protected void RewardGridView_RowEditing(object sender, GridViewEditEventArgs e) {
            RewardGridView.EditIndex = e.NewEditIndex;
            SelectAllReward();

            //active rewardtab
            string Script = "$('#nav-question').removeClass('active');$('#nav-reward').tab('show');$('#nav-question-btn').removeClass('active');$('#nav-reward-btn').addClass('active');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", Script, true);

            //focus textbox
            TextBox TotalEdit = (TextBox)RewardGridView.Rows[e.NewEditIndex].FindControl("RtotalTxt");
            TotalEdit.Focus();
        }

        protected void RewardGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            RewardGridView.EditIndex = -1;
            SelectAllReward();

            //active rewardtab
            string Script = "$('#nav-question').removeClass('active');$('#nav-reward').tab('show');$('#nav-question-btn').removeClass('active');$('#nav-reward-btn').addClass('active');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", Script, true);
        }

        protected void RewardGridView_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            string res = "";
            try {
                Reward rw = new Reward();
                rw.RID = RewardGridView.DataKeys[e.RowIndex]["RID"].ToString();
                TextBox TotalEdit = (TextBox)RewardGridView.Rows[e.RowIndex].FindControl("RtotalTxt");
                rw.Total = int.Parse(TotalEdit.Text);
                rw.UpdateReward();

                RewardGridView.EditIndex = -1;
                SelectAllReward();

                //active rewardtab
                res = "Swal.fire({type: 'success',title: 'OK'});$('#nav-question').tab('show');$('#nav-question').removeClass('active');$('#nav-reward').tab('show');$('#nav-question-btn').removeClass('active');$('#nav-reward-btn').addClass('active');";
            } catch (Exception ex) {
                res = "Swal.fire({type: 'error',title: '" + ex.Message + "'});$('#nav-question').tab('show');$('#nav-question').tab('show');$('#nav-question').removeClass('active');$('#nav-reward').tab('show');$('#nav-question-btn').removeClass('active');$('#nav-reward-btn').addClass('active');";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", res, true);
        }
    }
}