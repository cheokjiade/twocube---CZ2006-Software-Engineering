using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace twoCube.Account
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MembershipCreateStatus createStatus;
                string sUserName = tbUserName.Text;
                string sEmailAddress = tbEmailAddress.Text;
                string sPassword = tbPassword.Text;
                string sAge = tbAge.Text;
                string sLocation = tbLocation.Text;
                string sQuestion = tbQuestion.Text;
                string sAnswer = tbAnswer.Text;

                Membership.CreateUser(HttpUtility.HtmlEncode(sUserName.Trim()),
                                       HttpUtility.HtmlEncode(sPassword.Trim()),
                                       HttpUtility.HtmlEncode(sEmailAddress.Trim()),
                                       HttpUtility.HtmlEncode(sQuestion.Trim()),
                                       HttpUtility.HtmlEncode(sAnswer.Trim()),
                                       true,
                                       out createStatus);

                string CreateResultMessage = "";

                switch (createStatus)
                {
                    case MembershipCreateStatus.Success:
                        CreateResultMessage = "The user was successfully created.";
                        break;
                    case MembershipCreateStatus.InvalidUserName:
                        CreateResultMessage = "The user name was not found in the database.";
                        break;
                    case MembershipCreateStatus.InvalidPassword:
                        CreateResultMessage = "The password is not formatted correctly.";
                        break;
                    case MembershipCreateStatus.InvalidEmail:
                        CreateResultMessage = "The email is not formatted correctly.";
                        break;
                    case MembershipCreateStatus.InvalidQuestion:
                        CreateResultMessage = "The password question is not formatted correctly.";
                        break;
                    case MembershipCreateStatus.InvalidAnswer:
                        CreateResultMessage = "The password answer is not formatted correctly.";
                        break;
                    case MembershipCreateStatus.DuplicateEmail:
                        CreateResultMessage = "The email address already exists in the database for the application.";
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        CreateResultMessage = "The user name already exists in the database for the application.";
                        break;
                    case MembershipCreateStatus.UserRejected:
                        CreateResultMessage = "The user was not created, for a reason defined by the provider.";
                        break;
                    case MembershipCreateStatus.ProviderError:
                        CreateResultMessage = "The provider returned an error that is not described by other MembershipCreateStatus enumeration values.";
                        break;
                    case MembershipCreateStatus.InvalidProviderUserKey:
                        CreateResultMessage = "The provider user key is of an invalid type or format.";
                        break;
                    case MembershipCreateStatus.DuplicateProviderUserKey:
                        CreateResultMessage = "The ProviderUserKey already exists in the database for the application.";
                        break;

                    default:
                        CreateResultMessage = "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                        break;
                }

                if (createStatus != MembershipCreateStatus.Success)
                {
                    lblCreatingResultMessage.CssClass = "ValidationError";
                    btnAddUser.Visible = true;
                }
                else
                {
                    lblCreatingResultMessage.CssClass = "bold";
                    btnAddUser.Visible = false;
                }

                lblCreatingResultMessage.Text = CreateResultMessage;
                divResultMessage.Visible = true;
            }
        }
    }
}