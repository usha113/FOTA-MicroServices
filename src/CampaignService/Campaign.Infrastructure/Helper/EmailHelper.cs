using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;


namespace User.Infrastructure.Helper
{
    public class EmailHelper : IEmailHelper
    {
        public string fromAddress = "fota@wabco-auto.com";
        public string _userName = "";

        public async Task SendEmail(SmtpClient client, string toAddress, EmailType type, string message, string user = "")
        {
            _userName = user;
            using (MailMessage mail = new MailMessage(new MailAddress(fromAddress), new MailAddress(toAddress))
            {
                Subject = GenerateEmailSubject(type),
                Body = GenerateEmailContent(type, message),
                IsBodyHtml = true

            })
            {
                await client.SendMailAsync(mail);
            }
        }

       private string GenerateEmailSubject(EmailType type)
        {
            string subject = "";
            switch (type)
            {
                case EmailType.AccountCreated:
                    subject = "Welcome - Account Created";
                    break;
                case EmailType.Otp:
                    subject = "Your OTP to Login";
                    break;
                case EmailType.ResetPassword:
                    subject = "Password Reset";
                    break;
                case EmailType.UpdatePassword:
                    subject = "Password Change Request";
                    break;
                case EmailType.AccountUpdated:
                    subject = "Profile Details Updated";
                    break;
                case EmailType.AccountBlocked:
                    subject = "Account Blocked";
                    break;
            }
            return subject;
        }

        private string GenerateEmailContent(EmailType type, string message)
        {
            string template = "";
            switch(type)
            {
                case EmailType.AccountCreated:
                    template = GetAccountCreatedTemplate(message);
                    break;
                case EmailType.Otp:
                    template = GetOtpTemplate(message);
                    break;
                case EmailType.ResetPassword:
                    template = message;
                    break;
                case EmailType.UpdatePassword:
                    template = message;
                    break;
                case EmailType.AccountUpdated:
                    template = message;
                    break;
                case EmailType.AccountBlocked:
                    template = message;
                    break;
            }
            return template;
        }

        #region OTP HTML Template
        private string GetOtpTemplate(string message)
        {
            string head = @"<head>
            <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
            <title>Your OTP to Login</title>
            <style type = 'text/css'>
            .ReadMsgBody {
                width: 100%;
                background-color: #ffffff;
              }
                .ExternalClass {
                width: 100%;
                background-color: #ffffff;
                line-height: 100% important;
              }
             .body {
               width: 100%;
                background-color: #ffffff;
                margin: 0;
                padding: 0;
                -webkit-font-smoothing; antialized;
              }
            * {
                                font - family: Arial, Helvetica, sans-serif;
                            }
                            table {
                                border - collapse: collapse;
                            }
                            @media only screen and (max-width: 640px) {
                                body[yahoo] .deviceWidth {
                                    width: 440px !important;
                                    padding: 0;
                                }

                                body[yahoo] .quote {
                                    font-size: 22px !important;
                                }

                                body[yahoo] .center {
                                    text-align: center !important;
                                }

                                td[class=menumobile] {
                                    text-align: center !important;
                                    padding: 21px 20px !important;
                                }

                                td[class=socialmobile] {
                                    text-align: center !important;
                                    padding: 21px 170px 21px 10px !important;
                                }
                            }

                            @media only screen and (max-width: 479px) {
                                body[yahoo] .deviceWidth {
                                    width: 280px !important;
                                    padding: 0;
                                }

                                body[yahoo] .quote {
                                    font-size: 20px !important;
                                }

                                body[yahoo] .center {
                                    text-align: center !important;
                                }

                                td[class=menumobile] {
                                    text-align: center !important;
                                    padding: 21px 20px !important;
                                }

                                td[class=socialmobile] {
                                    text-align: center !important;
                                    padding: 1px 65px 1px 10px !important;
                                }

                                td[class=mobiletext] {
                                    font-size: 20px !important;
                                }

                                img[class=mobileout] {
                                    display: none !important;
                                }
                            }
                        </style>
                    </head>";
            return String.Format(@"<!doctype html>
                    <html xmlns='http://www.w3.org/1999/xhtml'>
                    {3}

                    <body leftmargin='0' topmargin='0' marginwidth='0' marginheight='0' yahoo='fix'
                        style='font-family: Arial, Helvetica,  sans-serif'>
                        <table id='backgroundTable' bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
                            <tr>
                                <td>
                                    <table bgcolor='#ffffff' width='700' border='0' cellpadding='0' cellspacing='0' align='center'
                                        class='deviceWidth'>
                                        <tr>
                                            <td width='100%'>
                                                <table class='devicewidth' align='center' border='0' cellpadding='0' cellspacing='0'
                                                    width='100%'>
                                                    <tr>
                                                        <td style='padding:15px 0px 15px'>
                                                            <table align='left' width='29%' cellpadding='0' cellspacing='0' border='0'
                                                                class='deviceWidth'>
                                                                <tr>
                                                                    <td valign='top' align='center' class='center'
                                                                        style='padding-top:15px; padding-bottom:10px;'>
                                                                        <a href='http://www.wabco-auto.com' target='_blank'>
                                                                            <img width='150' src='../Images/logo.png' alt='' border='0'
                                                                                style='border-radius: 0px; width: 150px; display: block;'
                                                                                class='deviceWidth' />
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table align='right' width='21%' cellpadding='0' cellspacing='0' border='0'
                                                                class='deviceWidth'>
                                                                <tr>
                                                                    <td
                                                                        style='font-size: 15px; color: #333333; font-weight: normal; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 28px; vertical-align: top; padding:10px 20px 0px 0px'>
                                                                        <table width='100%'>
                                                                            <tr>
                                                                                <td
                                                                                    style='font-family: Arial, Helvetica, sans-serif; font-size: 16px; color: #666666; text-align:center;line-height: 30px; padding: 3px 2px;'>
                                                                                    <span
                                                                                        style='font-family: Arial, Helvetica, sans-serif'> {0} </span>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign='top' align='center' class='center' style=''>
                                                            <img src='../Images/color_bar_new.jpg' width='700' alt='' border='0'
                                                                style='border-radius: 0px; width: 700px; display: block;'
                                                                class='deviceWidth' />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
                            <tr>
                                <td>
                                    <table width='700' class='deviceWidth' border='0' cellpadding='0' cellspacing='0' align='center'>
                                        <tr>
                                            <td width='100%' style='padding:0px;'>
                                                <table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'
                                                    class='devicewidth' style=''>
                                                    <tr>
                                                        <td style='font-size: 14px; color: #333333; text-align: left; font-family: Arial, Helvetica,  sans-serif; line-height: 24px; vertical-align: top; padding:20px 0 0 0; '
                                                            width='99%'>
                                                            <p style='mso-table-lspace:0;mso-table-rspace:0; margin:0;'>
                                                                <span style='font-family: Arial, Helvetica, sans-serif '>Dear
                                                                    <b>{1},</b></span>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style='font-size: 14px; color: #333333; text-align: left; font-family: Arial, Helvetica,  sans-serif; line-height: 24px; vertical-align: top; padding:20px 0 0 0; '
                                                            width='99%'>
                                                            <p style='mso-table-lspace:0;mso-table-rspace:0; margin:0;'>
                                                                <span style='font-family: Arial, Helvetica, sans-serif '>Your one time
                                                                    password (OTP) to login is {2}</span>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style='font-size: 14px; color: #333333; text-align: left; font-family: Arial, Helvetica,  sans-serif; line-height: 24px; vertical-align: top; padding:20px 0 0 0; '
                                                            width='99%'>
                                                            <p style='mso-table-lspace:0;mso-table-rspace:0; margin:0;'>
                                                                <span style='font-family: Arial, Helvetica, sans-serif '>Do not share the
                                                                    OTP with anyone. This is valid only for 30 minutes.
                                                                    In case of any queries or assistance, please call us on our 24x7 Toll
                                                                    Free Helpline 1234 5678 or write to us at
                                                                    support@wabcofleetsolutions.com</span>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
                            <tr>
                                <td>
                                    <table width='650' class='deviceWidth' border='0' cellpadding='0' cellspacing='0' align='center'
                                        bgcolor='#ffffff'>
                                        <tr>
                                            <td width='100%'>
                                                <table class='devicewidth' align='center' border='0' cellpadding='0' cellspacing='0'
                                                    width='100%'>
                                                    <tr>
                                                        <td
                                                            style='font-size: 13px; color: #a2a2a2; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 24px; vertical-align: top; padding:15px 0;'>
                                                            <table width='100%'>
                                                                <tr>
                                                                    <td valign='middle'></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
                            <tr>
                                <td>
                                    <table width='650' class='deviceWidth' border='0' cellpadding='0' cellspacing='0' align='center'
                                        bgcolor='#ffffff'>
                                        <tr>
                                            <td width='100%'>
                                                <table class='devicewidth' align='center' border='0' cellpadding='0' cellspacing='0'
                                                    width='100%'>
                                                    <tr>
                                                        <td
                                                            style='font-size: 13px; color: #a2a2a2; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 24px; vertical-align: top; padding:15px 0;'>
                                                            <table width='100%'>
                                                                <tr>
                                                                    <td valign='middle'></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
                            <tr>
                                <td>
                                    <table width='700' class='deviceWidth' border='0' cellpadding='0' cellspacing='0' align='center'>
                                        <tr>
                                            <td width='100%' style='padding:0px;'>
                                                <table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'
                                                    class='devicewidth'>
                                                    <tr>
                                                    <tr>
                                                        <td height='1' bgcolor='#e6e8e9' style='line-height:1px;font-size:1px;'>&nbsp;</td>
                                                    </tr>
                                            <td style='font-size: 11px; color: #333333; text-align: center; font-family: Arial, Helvetica,  sans-serif;  vertical-align: top; padding:10px 0 0 0; '
                                                width='99%'>

                                                All other trademarks and registered trademarks are the property of their
                                                respective owners.<br />
                                                Please do not reply to this email. WABCO's <a
                                                    href='http://www.wabco-auto.com/footer/legal/web-privacy-policy/' target='_blank'
                                                    style='color:#005baa;text-decoration:underline;'>Privacy
                                                    Policy</a><br />
                                                <a href='https://www.wabco-atpace.com/' target='_blank'
                                                    style='color:#005baa;text-decoration:underline;'>@PACE</a> | <a
                                                    href='http://www.wabco-auto.com' target='_blank'
                                                    style='color:#005baa;text-decoration:underline;'>www.wabco-auto.com</a><br />
                                                <br /><br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </td>
                        </tr>
                        </table>
                        <div style='display:none; white-space:nowrap; font:15px courier; color:#ffffff;'>
                            - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
                        </div>
                    </body>
                </html>", DateTime.Now.Date.ToString("MMM dd yyyy"), _userName, message, head);
        }
        #endregion

        #region Account Created HTML Template
        private string GetAccountCreatedTemplate(string message)
        {
            string head = @"<head>
				<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
				<title>Account Created</title>
				<style type='text/css'>
					.ReadMsgBody {
						width: 100%;
						background-color: #ffffff;
					}
					.ExternalClass {
						width: 100%;
						background-color: #ffffff;
						line-height: 100% !important;
					}
					body {
						width: 100%;
						background-color: #ffffff;
						margin: 0;
						padding: 0;
						-webkit-font-smoothing: antialiased;
					}
					* {
						font-family: Arial, Helvetica, sans-serif;
					}
					table {
						border-collapse: collapse;
					}
					@media only screen and (max-width: 640px) {
						body[yahoo] .deviceWidth {
							width: 440px !important;
							padding: 0;
						}
						body[yahoo] .quote {
							font-size: 22px !important;
						}
						body[yahoo] .center {
							text-align: center !important;
						}
						td[class=menumobile] {
							text-align: center !important;
							padding: 21px 20px !important;
						}
						td[class=socialmobile] {
							text-align: center !important;
							padding: 21px 170px 21px 10px !important;
						}
					}

					@media only screen and (max-width: 479px) {
						body[yahoo] .deviceWidth {
							width: 280px !important;
							padding: 0;
						}
						body[yahoo] .quote {
							font-size: 20px !important;
						}
						body[yahoo] .center {
							text-align: center !important;
						}
						td[class=menumobile] {
							text-align: center !important;
							padding: 21px 20px !important;
						}
						td[class=socialmobile] {
							text-align: center !important;
							padding: 1px 65px 1px 10px !important;
						}
						td[class=mobiletext] {
							font-size: 20px !important;
						}
						img[class=mobileout] {
							display: none !important;
						}
					}
				</style>
			</head>";
            return String.Format(@"<!doctype html>
                    <html xmlns='http://www.w3.org/1999/xhtml'>
                    {3}
                    <body leftmargin='0' topmargin='0' marginwidth='0' marginheight='0' yahoo='fix'
						style='font-family: Arial, Helvetica,  sans-serif'>
						<table id='backgroundTable' bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
							<tr>
								<td>
									<table bgcolor='#ffffff' width='700' border='0' cellpadding='0' cellspacing='0' align='center'
										class='deviceWidth'>
										<tr>
											<td width='100%'>
												<table class='devicewidth' align='center' border='0' cellpadding='0' cellspacing='0'
													width='100%'>
													<tr>
														<td style='padding:15px 0px 15px'>
															<table align='left' width='29%' cellpadding='0' cellspacing='0' border='0'
																class='deviceWidth'>
																<tr>
																	<td valign='top' align='center' class='center'
																		style='padding-top:15px; padding-bottom:10px;'>
																		<a href='http://www.wabco-auto.com' target='_blank'>
																			<img width='150' src='images/otp/logo.png' alt='' border='0'
																				style='border-radius: 0px; width: 150px; display: block;'
																				class='deviceWidth' />
																		</a>
																	</td>
																</tr>
															</table>
															<table align='right' width='21%' cellpadding='0' cellspacing='0' border='0'
																class='deviceWidth'>
																<tr>
																	<td
																		style='font-size: 15px; color: #333333; font-weight: normal; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 28px; vertical-align: top; padding:10px 20px 0px 0px'>
																		<table width='100%'>
																			<tr>
																				<td
																					style='font-family: Arial, Helvetica, sans-serif; font-size: 16px; color: #666666; text-align:center;line-height: 30px; padding: 3px 2px;'>
																					<span
																						style='font-family: Arial, Helvetica, sans-serif '> {0} </span>
																				</td>
																			</tr>
																		</table>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td valign='top' align='center' class='center' style=''>
															<img src='images/otp/color_bar_new.jpg' width='700' alt='' border='0'
																style='border-radius: 0px; width: 700px; display: block;'
																class='deviceWidth' />
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
							<tr>
								<td>
									<table width='700' class='deviceWidth' border='0' cellpadding='0' cellspacing='0' align='center'>
										<tr>
											<td width='100%' style='padding:0px;'>
												<table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'
													class='devicewidth' style=''>
													<tr>
														<td style='font-size: 14px; color: #333333; text-align: left; font-family: Arial, Helvetica,  sans-serif; line-height: 24px; vertical-align: top; padding:20px 0 0 0; '
															width='99%'>
															<p style='mso-table-lspace:0;mso-table-rspace:0; margin:0;'>
																<span style='font-family: Arial, Helvetica, sans-serif '>Dear {1},</span>
															</p>
														</td>
													</tr>
													<tr>
														<td style='font-size: 14px; color: #333333; text-align: left; font-family: Arial, Helvetica,  sans-serif; line-height: 24px; vertical-align: top; padding:20px 0 0 0; '
															width='99%'>
															<p style='mso-table-lspace:0;mso-table-rspace:0; margin:0;'>
																<span style='font-family: Arial, Helvetica, sans-serif '>Congraluations, Your 
																	Fleet Management user account is successfully created. Please login using the
																	temporary password which was sent alongside this email.
																	Follow the steps on the portal or app to change the temporary password at the first login.
																</span>
															</p>
														</td>
													</tr>
													<tr>
														<td style='font-size: 14px; color: #333333; text-align: left; font-family: Arial, Helvetica,  sans-serif; line-height: 24px; vertical-align: top; padding:20px 0 0 0; '
															width='99%'>
															<p style='mso-table-lspace:0;mso-table-rspace:0; margin:0;'>
																<span style='font-family: Arial, Helvetica, sans-serif'>Contact our customer
																	service if you do not receive the temporary
																	password with this email or have trouble logging in using the temporary password
															</p>
														</td>
													</tr>
													<tr>
														<td style='font-size: 14px; color: #333333; text-align: left; font-family: Arial, Helvetica,  sans-serif; line-height: 24px; vertical-align: top; padding:20px 0 0 0; '
															width='99%'>
															<p style='mso-table-lspace:0;mso-table-rspace:0; margin:0;'>
																<span style='font-family: Arial, Helvetica, sans-serif'> Your temporary password for login - <b> {2} </b>
															</p>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
							<tr>
								<td>
									<table width='650' class='deviceWidth' border='0' cellpadding='0' cellspacing='0' align='center'
										bgcolor='#ffffff'>
										<tr>
											<td width='100%'>
												<table class='devicewidth' align='center' border='0' cellpadding='0' cellspacing='0'
													width='100%'>
													<tr>
														<td
															style='font-size: 13px; color: #a2a2a2; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 24px; vertical-align: top; padding:15px 0;'>
															<table width='100%'>
																<tr>
																	<td valign='middle'></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
							<tr>
								<td>
									<table width='650' class='deviceWidth' border='0' cellpadding='0' cellspacing='0' align='center'
										bgcolor='#ffffff'>
										<tr>
											<td width='100%'>
												<table class='devicewidth' align='center' border='0' cellpadding='0' cellspacing='0'
													width='100%'>
													<tr>
														<td style='font-size: 13px; color: #a2a2a2; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 24px; vertical-align: top; padding:15px 0;'>
															<table width='100%'>
																<tr>
																	<td valign='middle'></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<table bgcolor='#ffffff' border='0' cellpadding='0' cellspacing='0' width='100%'>
							<tr>
								<td>
									<table width='700' class='deviceWidth' border='0' cellpadding='0' cellspacing='0' align='center'>
										<tr>
											<td width='100%' style='padding:0px;'>
												<table width='100%' cellspacing='0' cellpadding='0' border='0' align='center'
													class='devicewidth'>
													<tr>
														<td style='font-size: 14px; color: #333333; text-align: center; font-family: Arial, Helvetica,  sans-serif; line-height: 24px; vertical-align: top; padding:20px 0 0 0; '
															width='99%'>
															<p style='mso-table-lspace:0;mso-table-rspace:0; margin:0;'>
																<span style='font-family: Arial, Helvetica, sans-serif;'> In case of any
																	queries or assistance, please call us on our 24x7 Toll
																	Free Helpline <span style='color:#0098b2'>1234 5678 </span>or write to
																	us at <a
																		style='font-family:Arial, Helvetica, sans-serif; color:#0098b2; text-decoration:underline; font-size:13px; text-align:center'>fms.domain@wabco-auto.com</a></span>
															</p>
														</td>
													</tr>
													<tr>
													<tr>
														<td height='1' bgcolor='#e6e8e9' style='line-height:1px;font-size:1px;'>&nbsp;</td>
													</tr>
													<td style='font-size: 11px; color: #333333; text-align: center; font-family: Arial, Helvetica,  sans-serif;  vertical-align: top; padding:10px 0 0 0; '
														width='99%'>
														All other trademarks and registered trademarks are the property of their
														respective owners.<br />
														Please do not reply to this email. WABCO's <a
															href='http://www.wabco-auto.com/footer/legal/web-privacy-policy/'
															target='_blank' style='color:#0098b2;text-decoration:underline;'>Privacy
															Policy</a><br />
														<br /><br />
													</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						</td>
						</tr>
						</table>
						<div style='display:none; white-space:nowrap; font:15px courier; color:#ffffff;'>
							- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
						</div>
					</body>
                </html>", DateTime.Now.Date.ToString("MMM dd yyyy"), _userName, message, head);
        }
        #endregion
    }
    public enum EmailType
    {
        AccountCreated,
        ResetPassword,
        UpdatePassword,
        Otp,
        AccountUpdated,
        AccountBlocked
    }

    public interface IEmailHelper
    {
        Task SendEmail(SmtpClient client, string toAddress, EmailType type, string message, string user = "");
    }
}
