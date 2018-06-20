<?php

class ConnectionInfo
{
	public $mServerName;
	public $mConnectionInfo;
	public $conn;
	
	public function GetConnection()
	{
		$this->mServerName = 'localhost';
		$this->mConnectionInfo = array("Database"=>"HairSalon", "UID"=>"root", "PWD"=>"root");
		$this->conn = sqlsrv_connect($this->mServerName,$this->mConnectionInfo);
		
		return $this->conn;
	}
}
?>