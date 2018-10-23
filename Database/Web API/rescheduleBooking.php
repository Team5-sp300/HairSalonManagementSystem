<?php
require_once(dirname(__FILE__).'/ConnectionInfo.php');

$connectionInfo = new ConnectionInfo();
$con=$connectionInfo->GetConnection();

if (isset($_POST['id']) && isset ($_POST['adate']) && isset ($_POST['atime'])&& isset ($_POST['service'])) {

    $id = $_POST['id'];
    $newDate = $_POST['adate'];
    $newTime = $_POST['atime'];
    $newService = $_POST['service'];

    if (!$con) {
        die("Connection failed: " . mysqli_connect_error());
    }


    $sql = "Call updateBooking('$id', '$newDate', '$newTime', '$newService')";


    if (mysqli_query($con, $sql)) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($con);
    }
    mysqli_close($con);
}
?>