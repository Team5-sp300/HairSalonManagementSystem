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

$sql = "SELECT EmployeeName,EmployeePassword FROM Employee";
$result = $conn->query($sql);

$contacts = array();

if ($result->num_rows > 0) {

      while($row = mysqli_fetch_assoc($result)) {
          $contact = array("name" => $row['EmployeeName'],"password" => $row['EmployeePassword']);

          //Add the contact to the contacts array
          array_push($contacts, $contact);


      }
    echo json_encode($contacts);
} else {
    echo "0 results";
}
$conn->close();
?>
