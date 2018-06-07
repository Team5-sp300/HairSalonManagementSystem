<?php
header('Content-type: application/json');
mysql_connect ("127.0.0.1","root","root");
mysql_select_db("HairSalonDB");
	$sql="SELECT * FROM booking;"
	$result=mysql_query($sql);
while($e=mysql_fetch_assoc($result)){
	$output[]=$e;		
	}
echo json_encode($output);
print (json_encode($output));

?>