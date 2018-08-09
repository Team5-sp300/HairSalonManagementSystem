<?php
require_once(dirname(__FILE__).'/ConnectionInfo.php');

$connectionInfo = new ConnectionInfo();
$con=$connectionInfo->GetConnection();

if (isset($_POST['cname']) && isset($_POST['ename'])&& isset($_POST['adate'])&& isset($_POST['atime'])) {
    //Get the POST variables
    $cname = $_POST['cname'];
    $ename = $_POST['ename'];
    $adate = $_POST['adate'];
    $atime = $_POST['atime'];
    // Create connection
// Check connection
    if (!$con) {
        die("Connection failed: " . mysqli_connect_error());
    }


    $sql = "Call insertBooking('$cname', '$ename','$adate','$atime')";


    if (mysqli_query($con, $sql)) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($con);
    }
    mysqli_close($con);
}
?>