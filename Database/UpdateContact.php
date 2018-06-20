<?php
	require_once(dirname(__FILE__).'/ConnectionInfo.php');

	
if (isset($_POST['Image']) && isset($_POST['ContactID']))
{
	//Get the POST variables
	$mImage = $_POST['Image'];
	$mContactID = $_POST['ContactID'];
	
	//Set up our connection
	$connectionInfo = new ConnectionInfo();
	$connectionInfo->GetConnection();
	
	if (!$connectionInfo->conn)
	{
		//Connection failed
		echo 'No Connection';
	}
	
	else
	{
		//The image is encoded in base 64 encoding, decode it
		$imgData = base64_decode($mImage);
		
		//Update contact with image
		$query = 'UPDATE Contacts SET Contacts_Image = CONVERT(VARBINARY(MAX), ?) WHERE Contacts_ID = ?';
		$parameters = array($imgData, $mContactID);

		//Execute query
		$stmt = sqlsrv_query($connectionInfo->conn, $query, $parameters);
		
		if (!$stmt)
		{	//The query failed
			echo 'Query Failed';	
		}
		
		else
		{
			//The query succeeded
			echo 'Successful';	
		}
	}
}

?>