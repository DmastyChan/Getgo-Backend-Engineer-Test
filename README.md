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
 
 <br/>
 Example : <br/>
 ============================================================== <br/>
 
 Example 1 : <br/>
 ![image](https://user-images.githubusercontent.com/121627145/210026773-09212489-01b8-4147-b70f-7f61e5793035.png)
 
 <br/>
 
 Example 2 : <br/>
 ![image](https://user-images.githubusercontent.com/121627145/210026831-68337600-29db-4c6b-85d0-150cf86d9cba.png)
 
 <br/>
 
 Example 3 : ( No allow to book , it is booked ) <br/>
![image](https://user-images.githubusercontent.com/121627145/210026867-a511b417-452e-4a06-b56a-f8c9257d4485.png)

Example 4 : ( No allow to book, it is because the user location is invalid, out of the distance ) <br/>
![image](https://user-images.githubusercontent.com/121627145/210026902-f7837583-48ef-47ba-a4bf-eba1397309c5.png)

Example 5 : ( No allow to book, it is because the user location is invalid, out of the distance ) <br/>
![image](https://user-images.githubusercontent.com/121627145/210026902-f7837583-48ef-47ba-a4bf-eba1397309c5.png)

Example 6 : ( Book Successfully ) <br/>
![image](https://user-images.githubusercontent.com/121627145/210026956-9ce1ee5d-f5fe-449b-a532-210becf36bec.png)

Example 7 : ( Reach a Car Home lot ) <br/>
![image](https://user-images.githubusercontent.com/121627145/210026985-27e303ef-87a9-4911-b27a-e815e647fe5b.png)

Example 8 : ( Invalid Geo X ) <br/>
![image](https://user-images.githubusercontent.com/121627145/210027127-8a4f5b20-d32c-4faf-aef5-ae45e3b7a064.png)




