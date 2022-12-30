# Getgo-Backend-Engineer-Test
----------------------------------
>.Net 7 <br/>
Database : SQL Lite <br/>
> Apply SwaggerUI <br/>

![image](https://user-images.githubusercontent.com/121627145/209978446-f7ba48c9-813d-4762-915a-755282068c94.png)
<br/>
1 ) Get all cars with details ( will display all the car with status )   <br/>
URL : /api/Record/All <br/>
Parameter : - 

2 ) Search car ( filter by the user location, and show the available car only ) <br/>
URL : /api/Record/search <br/>
Parameter : 
{
  "searchKeyWords": null ,
  "user": {
    "x": 0,
    "y": 0
  }
}
<br/>
<table>
  <tr>
    <th>Parameter</th>
    <th>Type</th>
    <th>Description</th>
  </tr>
   <tr>
    <td>searchKeyWords</td>
    <td>string, nullable</td>
    <td>To filter the text such as Brand, Model , Car's No Plate</td>
  </tr>
  <tr>
    <td>user.x</td>
    <td>Int</td>
    <td>User's Geo X </td>
  </tr>
  <tr>
    <td>user.y</td>
    <td>Int</td>
    <td>User's Geo Y </td>
  </tr>
 </table>
 <br/>
  3 ) Book a car ( Book a car with validate the user location ) <br/>
URL : /api/Record/book <br/>
Parameter : 
{
  "carId": 0 ,
  "user": {
    "x": 0,
    "y": 0
  }
}
<br/>
<table>
  <tr>
    <th>Parameter</th>
    <th>Type</th>
    <th>Description</th>
  </tr>
   <tr>
    <td>carId</td>
    <td>Int</td>
    <td>Car identity to for book</td>
  </tr>
  <tr>
    <td>user.x</td>
    <td>Int</td>
    <td>User's Geo X </td>
  </tr>
  <tr>
    <td>user.y</td>
    <td>Int</td>
    <td>User's Geo Y </td>
  </tr>
   </table>
 <br/>
  4 ) Reach Car's home-lot ( only available for the car was booked ) <br/>
URL : /api/Record/reach <br/>
Parameter : 
{
  "carId": 0 ,
  "user": {
    "x": 0,
    "y": 0
  }
}
<br/>
<table>
  <tr>
    <th>Parameter</th>
    <th>Type</th>
    <th>Description</th>
  </tr>
   <tr>
    <td>carId</td>
    <td>Int</td>
    <td>Car identity to reach</td>
  </tr>
  <tr>
    <td>user.x</td>
    <td>Int</td>
    <td>User's Geo X </td>
  </tr>
  <tr>
    <td>user.y</td>
    <td>Int</td>
    <td>User's Geo Y </td>
  </tr>
 </table>
