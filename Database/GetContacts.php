<?php
	require_once(dirname(__FILE__).'/ConnectionInfo.php');
	

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
		//Create query to retrieve all contacts
		$query = 'SELECT * FROM Contacts ORDER BY Contacts_ID';
		
		$stmt = sqlsrv_query($connectionInfo->conn, $query);
		
		if (!$stmt)
		{
			//Query failed
			echo 'Query failed';
		}
		
		else
		{
			$contacts = array(); //Create an array to hold all of the contacts
			//Query successful, begin putting each contact into an array of contacts
			
			while ($row = sqlsrv_fetch_array($stmt,SQLSRV_FETCH_ASSOC)) //While there are still contacts
			{
				//Create an associative array to hold the current contact
				//the names must match exactly the property names in the contact class in our C# code.
				$contact = array("ID" => $row['Contacts_ID'],
								 "Name" => $row['Contacts_Name'],
								 "Number" => $row['Contacts_Number'],
								 "ImageBase64" => base64_encode($row['Contacts_Image'])
								 );
								 
				//Add the contact to the contacts array
				array_push($contacts, $contact);
			}
			
			//Echo out the contacts array in JSON format
			echo json_encode($contacts);
		}
	}
?>