<?php

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

require './PHPMailer/src/Exception.php';
require './PHPMailer/src/PHPMailer.php';
require './PHPMailer/src/SMTP.php';

if (isset($_POST['cname']) && isset($_POST['ename']) && isset($_POST['adate']) && isset($_POST['atime']) && isset($_POST['service'])) {
    //Get the POST variables
    $cname = $_POST['cname'];
    $ename = $_POST['ename'];
    $adate = $_POST['adate'];
    $atime = $_POST['atime'];
    $service = $_POST['service'];

    $mail = new PHPMailer;

    $mail->isSMTP();                                      // Set mailer to use SMTP
    $mail->Host = 'smtp.gmail.com';  // Specify main and backup SMTP servers
    $mail->SMTPAuth = true;                               // Enable SMTP authentication
    $mail->Username = 'SP300Test@gmail.com';                 // SMTP username
    $mail->Password = '2018Group5';                           // SMTP password
    $mail->SMTPSecure = 'tsl';                           // Enable encryption, 'ssl' also accepted
    $mail->Port = 587;

//$mail->From = 'from@example.com';
//$mail->FromName = 'Mailer';
    $mail->setFrom('SP300Test@gmail.com', 'Heydt of Hair');
    $mail->addAddress('swabe@live.co.za', 'Andrew');     // Add a recipient

    $mail->WordWrap = 50;                                 // Set word wrap to 50 characters
//$mail->addAttachment('/var/tmp/file.tar.gz');         // Add attachments
//$mail->addAttachment('/tmp/image.jpg', 'new.jpg');    // Optional name
    $mail->isHTML(true);                                  // Set email format to HTML

    $mail->Subject = 'Hair Appointment';
    $mail->Body = '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
	<meta name="viewport" content="width=device-width" />
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />


</head>

<body bgcolor="#f5f5f5">
	<div style="font-family: \'Helvetica Neue\', \'Helvetica\', Helvetica, Arial, sans-serif;">
		<table class="head-wrap" bgcolor="#3f3f3f" style="margin: auto; width: 100%;">
			<tr>
				<td> </td>
				<td class="header container">
					<img src="cid:headerlogo" alt="" class="center" style="padding-top: 3%; padding-bottom: 3%; display: block; margin-left: auto; margin-right: auto;">
					<div class="content">
						<table bgcolor="#3f3f3f">
						</table>
					</div>
				</td>
				<td></td>
			</tr>
		</table>

		<table class="body-wrap" style="margin: auto; width: 50%;">
			<tr>
				<td></td>
				<td class="container" bgcolor="#FFFFFF" style="display:block!important; max-width:600px!important; margin:0 auto!important; clear:both!important;">
					<div class="content">
						<img src="cid:contentlogo" alt="" class="center" style="padding-top: 5%; display: block; margin-left: auto; margin-right: auto;">
						<table>
							<tr>
								<td>
									<h3 style="font-weight:500; font-size: 27px; line-height: 1.1; margin-bottom:15px; margin-left:15px; color:#000">Dear '.$cname.'</h3><br>
									<p class="lead" style="font-size:17px; font-family: Arial; margin-bottom: 10px;	font-weight: normal; line-height:1.6;margin-left:15px; ">
										We hereby confirm the change to your appointment at Heydt of Hair Design as follows: <br>
										Hairdresser: '.$ename.' <br>
										Date:  '.$adate.'  <br>
										Time: '.  $atime.'  <br>
										Service booked: '. $service.'  <br><br>
										If you wish to change your appointment, please contact us again. <br>
										<br>
										Kind regards, <br>
										<br>
										Heydt of Hair <br>
										<!-- social & contact -->
								</td>
							</tr>
						</table>
					</div>
				</td>
				<td></td>
			</tr>
		</table>

		<table class="footer-wrap" style="margin: auto; width: 50%; padding-top:30px">
			<tr>
				<td></td>
				<td class="container" style="display:block!important; max-width:600px!important; margin:0 auto!important; clear:both!important;">
					<table class="social" width="100%" style="background-color: #ebebeb;">
						<tr>
							<td>
								<table align="left" class="column" style="width: 280px; min-width: 279px; float:left;">
									<tr style="padding: 15px;">
										<td>
											<h5 class="" style="font-weight:500; font-size: 17px; line-height: 1.1; margin-bottom:15px; margin-left:30px; color:#000"><b>Connect with Us:</b></h5>
											<p class="" style="margin-left:30px; margin-right:30px;">
												<a href="#" class="soc-btn fb" style="padding: 3px 7px;
																			font-size:12px;
																			margin-bottom:10px;
																			text-decoration:none;
																			color: #FFF;font-weight:bold;
																			display:block;
																			text-align:center;
																			background-color: #3B5998!important;">Facebook</a>
												<a href="#" class="soc-btn tw" style="padding: 3px 7px;
																			font-size:12px;
																			margin-bottom:10px;
																			text-decoration:none;
																			color: #FFF;font-weight:bold;
																			display:block;
																			text-align:center;
																			background-color: #1daced!important;">Twitter</a>
												<a href="#" class="soc-btn gp" style="padding: 3px 7px;
																			font-size:12px;
																			margin-bottom:10px;
																			text-decoration:none;
																			color: #FFF;font-weight:bold;
																			display:block;
																			text-align:center;
																			background-color: #DB4A39!important;">Google+</a>
											</p>
										</td>
									</tr>
								</table>

								<table align="left" class="column" style="width: 250px; min-width: 279px; float:left;">
									<tr style="padding: 15px;">
										<td>

											<h5 class="" style="font-weight:500; font-size: 17px; line-height: 1.1; margin-bottom:15px; margin-left:30px; color:#000"><b>Contact Info:</b></h5>
											<p style="font-size:15px; font-family: Arial; margin-bottom: 10px;	font-weight: normal; line-height:1.6;margin-left:30px; ">Phone: +27 85 783 1922<br />
												Email: <strong><a href="emailto:luke@heydtofhair.com<">luke@heydtofhair.com</a></strong></p>

										</td>
									</tr>
								</table>
								<span class="clear"></span>
							</td>
						</tr>

						<div class="content">
							<table>
								<tr></tr>
							</table>
						</div>
					</table>
				</td>
				<td></td>
			</tr>
		</table>
	</div>
</body>

</html>
';
    $mail->AltBody = 'This is the body in plain text for non-HTML mail clients';

    if (!$mail->send()) {
        echo 'Message could not be sent.';
        echo 'Mailer Error: ' . $mail->ErrorInfo;
    } else {
        echo 'Message has been sent';
    }
}