using Students_Management.Dialogs;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        #region Private members
        private string _username = String.Empty;
        private string _email = String.Empty;
        private string _otp = String.Empty;
        private string _code = String.Empty;
        private bool _isGotOTP = false;
        #endregion

        #region Properties
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get => _username; set { _username = value; ValidateProperty(value); OnPropertyChanged(); } }
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get => _email; set { _email = value; ValidateProperty(value); OnPropertyChanged(); } }
        [Required(ErrorMessage = "OTP không được để trống")]
        public string OTP { get => _otp; set { _otp = value; ValidateProperty(value); OnPropertyChanged(); } }
        #endregion

        public ICommand GetOTPCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }

        public ForgotPasswordViewModel()
        {
            GetOTPCommand = new RelayCommand<Object>(
                (p) => 
                { 
                    return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Email); 
                }, 
                (p) => 
                {
                    _code = Guid.NewGuid().ToString();
                    try
                    {
                        SendMail($"Mã opt của bạn là: {_code}");                        
                        _isGotOTP = true;
                        MyMessageBox.Show("Gửi OTP thành công", "Mã OTP đã được gửi đến email của bạn");
                    } catch(Exception ex)
                    {
                        MyMessageBox.Show("Gửi OTP thất bại", "Một lỗi gì đó đã xảy ra");
                        _isGotOTP = false;
                    }
                    
                });

            ForgotPasswordCommand = new RelayCommand<Object>(
                (p) => 
                {
                    return _isGotOTP;
                }
                , 
                (p) =>
                {
                    if (OTP == _code)
                    {
                        try
                        {
                            SendMail($"Mật khẩu của bạn là: {DataProvider.Instance.DB.Users.Where(u => u.Username == Username).First().Password}");
                            MyMessageBox.Show("Mật khẩu đã được gửi đến email của bạn");
                        }
                        catch (Exception ex)
                        {
                            MyMessageBox.Show("Gửi mật khẩu thất bại", "Một lỗi gì đó đã xảy ra");
                        }
                        
                    }      
                });
        }

        private void SendMail(string content)
        {
            try
            {
                // Create a mail
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("duyquang.maple01@gmail.com");
                mail.To.Add(Email);
                mail.Subject = "OTP - Quản lý học sinh";
                mail.Body = content;

                // Create smtp server
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("duyquang.maple01@gmail.com", "Kukiduyquang");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                
            } catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
