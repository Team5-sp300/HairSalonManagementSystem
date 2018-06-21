<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "HairSalon";

$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT firstname FROM Employee";
$result = $conn->query($sql);

$contacts = array();

if ($result->num_rows > 0) {
    // output data of each row
    while ($row = $result->fetch_assoc()) {
        $contact = array("Name" => $row['EmployeeName'],);

        //Add the contact to the contacts array
        array_push($contacts, $contact);

        echo json_encode($contacts);
    }
} else {
    echo "0 results";
}
$conn->close();
?>
