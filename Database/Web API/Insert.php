<?php
require_once(dirname(__FILE__).'/ConnectionInfo.php');

$connectionInfo = new ConnectionInfo();
$con=$connectionInfo->GetConnection();

if (isset($_POST['Name']) && isset($_POST['Password'])) {
    //Get the POST variables
    $mName = $_POST['Name'];
    $mPassword = $_POST['Password'];
    // Create connection
// Check connection
    if (!$conn) {
        die("Connection failed: " . mysqli_connect_error());
    }


    $sql = "INSERT INTO Employee (EmployeeName, EmployeePassword)
VALUES ('$mName', '$mPassword')";


    if (mysqli_query($conn, $sql)) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($conn);
    }

    mysqli_close($conn);
}
?>