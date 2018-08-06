<?php
require_once(dirname(__FILE__).'/ConnectionInfo.php');

$connectionInfo = new ConnectionInfo();
$con=$connectionInfo->GetConnection();

if (isset($_POST['fname']) && isset($_POST['lname'])&& isset($_POST['number'])&& isset($_POST['email'])) {
    //Get the POST variables
    $fname = $_POST['fname'];
    $lname = $_POST['lname'];
    $phone = $_POST['number'];
    $email = $_POST['email'];
    // Create connection
// Check connection
    if (!$con) {
        die("Connection failed: " . mysqli_connect_error());
    }


    $sql = "Call insertClient('$fname', '$lname','$phone','$email')";


    if (mysqli_query($con, $sql)) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($con);
    }

    mysqli_close($con);
}
?>