<?php
require_once(dirname(__FILE__).'/ConnectionInfo.php');

$connectionInfo = new ConnectionInfo();
$con=$connectionInfo->GetConnection();

if (isset($_POST['cfname']) && isset($_POST['clname']) && isset($_POST['efname'])&& isset($_POST['elname'])&& isset($_POST['adate'])&& isset($_POST['atime'])&& isset($_POST['service'])) {
    //Get the POST variables
    $cfname = $_POST['cfname'];
    $clname = $_POST['clname'];
    $efname = $_POST['efname'];
    $elname = $_POST['elname'];
    $adate = $_POST['adate'];
    $atime = $_POST['atime'];
    $service = $_POST['service'];
    // Create connection
// Check connection
    if (!$con) {
        die("Connection failed: " . mysqli_connect_error());
    }


    $sql = "Call insertBooking('$cfname', '$clname','$efname', '$elname','$adate','$atime','$service')";


    if (mysqli_query($con, $sql)) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($con);
    }
    mysqli_close($con);
}
?>