<?php

class ConnectionInfo
{
	public function GetConnection()
	{
        $servername = "localhost";
        $username = "root";
        $password = "";
        $dbname = "HairSalon";

        $conn = new mysqli($servername, $username, $password, $dbname);

		return $conn;
	}
}
?>