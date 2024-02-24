# Miles CarRental
Sistema de busqueda de vehiculos para Miles Car Rental.

Miles Car Rental, una empresa lider en la industria del alquiler de vehículos, busca implementar un sistema de búsqueda avanzado que permita a sus clientes encontrar vehículos disponibles
de manera eficiente y precisa. Este sistema se diseñará para cumplir con los criterios especificos de búsqueda que requiere la empresa, asegurando una experiencia óptimia para sus usuarios.

## Curls de consumo
| Objeto    | Curl  | 
|---------------|----------------|
| Client   |  curl -X 'GET' \ 'https://localhost:44372/api/Client/GetClients' \ -H 'accept: */*'   |
| Available Vehicles   |  curl -X 'GET' \ 'https://localhost:44372/api/Vehicle/GetAvailableVehicles?pickupLocationCity=Cali&returnLocationCity=Bogota' \ -H 'accept: */*'  |
| Vehicles By Market   |  curl -X 'GET' \ 'https://localhost:44372/api/Market/GetAvailableVehiclesByMarket?cityClientLocation=Bogota&cityReturnLocation=Cali' \  -H 'accept: */*'   |
