<?php
require_once(dirname(__FILE__).'/ConnectionInfo.php');

$connectionInfo = new ConnectionInfo();
$con=$connectionInfo->GetConnection();

if (isset($_POST['id'])) {
    //Get the POST variables
    $id = $_POST['id'];

    // Create connection
// Check connection
    if (!$con) {
        die("Connection failed: " . mysqli_connect_error());
    }


    $sql = "Call cancelAppointment('$id')";


    if (mysqli_query($con, $sql)) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($con);
    }
    mysqli_close($con);
}
?>