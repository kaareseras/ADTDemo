using System.Threading.Tasks;

namespace SampleClientApp
{
    public class BuildingScenario
    {
        private readonly CommandLoop cl;
        public BuildingScenario(CommandLoop cl)
        {
            this.cl = cl;
        }

        public async Task InitBuilding()
        {
            Log.Alert($"Deleting all twins...");
            await cl.DeleteAllTwinsAsync();
            
            Log.Out($"Creating ...");
            await InitializeGraph();
            await Create_Models();
            await Create_Access_Rel();
            await Create_Sensors();
            await Create_Meter();
        }

        private async Task InitializeGraph()
        {
            string[] modelsToUpload = new string[11] 
                {
                    "CreateModels", 
                    "SiteInterface", 
                    "BuildingInterface", 
                    "AreaInterface",
                    "FloorInterface",
                    "RoomInterface",
                    "HA_Sensor_unit",
                    "IoTHub_Enviromental_Sensor",
                    "Voltage_Sensor",
                    "Power_Sensor",
                    "Current_Sensor"
                };
            Log.Out($"Uploading {string.Join(", ", modelsToUpload)} models");

            await cl.CommandCreateModels(modelsToUpload);
        
        }
        private async Task Create_Models()
        {

            Log.Out($"Creating SiteModels...");
            await cl.CommandCreateDigitalTwin(new string[6]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Site;1", "Skonnertvej",
                    "SiteName", "string", "Skonnertvej"

                });
            Log.Out($"Creating BuildingModels...");
            await cl.CommandCreateDigitalTwin(new string[9]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Building;1", "House",
                    "BuildingName", "string", "House",
                    "BuildingArea", "double", "160"
                });
            await cl.CommandCreateDigitalTwin(new string[9]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Building;1", "Garage",
                    "BuildingName", "string", "Garage",
                    "BuildingArea", "double", "50"
                });
            Log.Out($"Creating AreaModels...");
            await cl.CommandCreateDigitalTwin(new string[6]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Area;1", "Driveway",
                    "AreaName", "string", "Driveway"

                });
            Log.Out($"Creating FloorModels...");
            await cl.CommandCreateDigitalTwin(new string[12]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Floor;1", "GroundLevel",
                    "FlorName", "string", "GroundLevel",
                    "FloorArea", "double", "160",
                    "FloorLevel", "double", "0"
                });
            await cl.CommandCreateDigitalTwin(new string[12]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Floor;1", "Basement",
                    "FlorName", "string", "Basement",
                    "FloorArea", "double", "160",
                    "FloorLevel", "double", "0"

                });
            await cl.CommandCreateDigitalTwin(new string[12]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Floor;1", "Attic",
                    "FlorName", "string", "Attic",
                    "FloorArea", "double", "160",
                    "FloorLevel", "double", "0"

                });
            Log.Out($"Creating RoomModels...");
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Livingroom",
                    "RoomName", "string", "Livingroom",
                    "Temperature", "double", "30",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "30"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Diningroom",
                    "RoomName", "string", "Diningroom",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "15"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Kitchen",
                    "RoomName", "string", "Kitchen",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "15"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Hall",
                    "RoomName", "string", "Hall",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "12"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Utility",
                    "RoomName", "string", "Utility",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "12"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Bedroom",
                    "RoomName", "string", "Bedroom",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "12"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Walkin",
                    "RoomName", "string", "Walkin",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Bathroom",
                    "RoomName", "string", "Bathroom",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });
             await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "SmallBathroom",
                    "RoomName", "string", "SmallBathroom",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Office",
                    "RoomName", "string", "Office",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Jakobsroom",
                    "RoomName", "string", "Jakobsroom",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Atticroom",
                    "RoomName", "string", "Atticroom",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Preroom",
                    "RoomName", "string", "Preroom",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Workshop",
                    "RoomName", "string", "Workshop",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });
            await cl.CommandCreateDigitalTwin(new string[18]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Room;1", "Hobbyroom",
                    "RoomName", "string", "Hobbyroom",
                    "Temperature", "double", "0",
                    "Humidity", "double", "0",
                    "Ocupied", "boolean", "false",
                    "RoomArea", "double", "8"
                });








            Log.Out($"Creating edges  Site -> Houses/Areas");
            
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Skonnertvej", "rel_has_building", "House", "rel_has_building"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Skonnertvej", "rel_has_building", "Garage", "rel_has_building_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Skonnertvej", "rel_has_area", "Driveway", "rel_has_area"
                });
            Log.Out($"Creating edges Houses -> Floors");
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "House", "rel_has_floor", "GroundLevel", "rel_has_floor_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "House", "rel_has_floor", "Basement", "rel_has_floor_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "House", "rel_has_floor", "Attic", "rel_has_floor_3"
                });

            //*******************  Flor has Rooms  ************************
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Livingroom", "rel_has_room_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Diningroom", "rel_has_room_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Kitchen", "rel_has_room_3"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Hall", "rel_has_room_4"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Utility", "rel_has_room_5"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Bedroom", "rel_has_room_6"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Walkin", "rel_has_room_7"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Bathroom", "rel_has_room_8"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "SmallBathroom", "rel_has_room_9"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Office", "rel_has_room_10"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "GroundLevel", "rel_has_room", "Jakobsroom", "rel_has_room_11"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Attic", "rel_has_room", "Atticroom", "rel_has_room_12"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Basement", "rel_has_room", "Preroom", "rel_has_room_13"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Basement", "rel_has_room", "Workshop", "rel_has_room_14"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Basement", "rel_has_room", "Hobbyroom", "rel_has_room_15"
                });
        }

        private async Task Create_Access_Rel()
        {

            //*******************  ACCESS TO  ************************
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Livingroom", "rel_has_access_to", "Diningroom", "rel_has_access_to_1_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Diningroom", "rel_has_access_to", "Livingroom", "rel_has_access_to_1_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Kitchen", "rel_has_access_to", "Diningroom", "rel_has_access_to_2_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Diningroom", "rel_has_access_to", "Kitchen", "rel_has_access_to_2_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Kitchen", "rel_has_access_to", "Utility", "rel_has_access_to_3_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Utility", "rel_has_access_to", "Kitchen", "rel_has_access_to_3_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "Utility", "rel_has_access_to_4_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Utility", "rel_has_access_to", "Hall", "rel_has_access_to_4_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "Livingroom", "rel_has_access_to_5_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Livingroom", "rel_has_access_to", "Hall", "rel_has_access_to_5_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "Bedroom", "rel_has_access_to_6_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Bedroom", "rel_has_access_to", "Hall", "rel_has_access_to_6_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Bedroom", "rel_has_access_to", "Walkin", "rel_has_access_to_7_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Walkin", "rel_has_access_to", "Bedroom", "rel_has_access_to_7_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "Bathroom", "rel_has_access_to_8_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Bathroom", "rel_has_access_to", "Hall", "rel_has_access_to_8_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "SmallBathroom", "rel_has_access_to_9_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "SmallBathroom", "rel_has_access_to", "Hall", "rel_has_access_to_9_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "Office", "rel_has_access_to_10_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Office", "rel_has_access_to", "Hall", "rel_has_access_to_10_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "Jakobsroom", "rel_has_access_to_11_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Jakobsroom", "rel_has_access_to", "Hall", "rel_has_access_to_11_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "Atticroom", "rel_has_access_to_12_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Atticroom", "rel_has_access_to", "Hall", "rel_has_access_to_12_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hall", "rel_has_access_to", "Preroom", "rel_has_access_to_13_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Preroom", "rel_has_access_to", "Hall", "rel_has_access_to_13_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Preroom", "rel_has_access_to", "Workshop", "rel_has_access_to_14_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Workshop", "rel_has_access_to", "Preroom", "rel_has_access_to_14_2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Workshop", "rel_has_access_to", "Hobbyroom", "rel_has_access_to_15_1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hobbyroom", "rel_has_access_to", "Workshop", "rel_has_access_to_15_2"
                });




        }
    
        private async Task Create_Sensors()
        {
            //IoT ESP32 sensor
            await cl.CommandCreateDigitalTwin(new string[6]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:IoTHub_Enviromental_Sensor;1", "ESP8266_Demo",
                    "Temperature", "double", "0"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "Hobbyroom", "rel_has_IoTHub_Enviromental_Sensor", "ESP8266_Demo", "rel_has_IoTHub_Enviromental_Sensor_1"
                });
        }

    private async Task Create_Meter() 
        {
            
            //PowerMeter
            await cl.CommandCreateDigitalTwin(new string[9]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:HA_Sensor_Unit;1", "ElectricMeter",
                    "Manufacturer", "string", "ABB",
                    "Active", "boolean", "true"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "House", "rel_has_HA_Sensor_Unit", "ElectricMeter", "rel_has_HA_Sensor_Unit_1"
                });
            
            
            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Voltage_Sensor;1", "U1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Voltage_Sensor", "U1", "rel_has_Voltage_Sensor_U1"
                });
            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Voltage_Sensor;1", "U2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Voltage_Sensor", "U2", "rel_has_Voltage_Sensor_U2"
                });
            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Voltage_Sensor;1", "U3"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Voltage_Sensor", "U3", "rel_has_Voltage_Sensor_U3"
                });

            
            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Current_Sensor;1", "I1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Current_Sensor", "I1", "rel_has_Current_Sensor_I1"
                });
            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Current_Sensor;1", "I2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Current_Sensor", "I2", "rel_has_Current_Sensor_I2"
                });
            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Current_Sensor;1", "I3"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Current_Sensor", "I3", "rel_has_Current_Sensor_I3"
                });


            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Power_Sensor;1", "P1"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Power_Sensor", "P1", "rel_has_Power_Sensor_P1"
                });
            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Power_Sensor;1", "P2"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Power_Sensor", "P2", "rel_has_Power_Sensor_P2"
                });
            await cl.CommandCreateDigitalTwin(new string[3]
                {
                    "CreateTwin", "dtmi:com:microsoft:iot:e2e:SmartHouse:Power_Sensor;1", "P3"
                });
            await cl.CommandCreateRelationship(new string[5]
                {
                    "CreateEdge", "ElectricMeter", "rel_has_Power_Sensor", "P3", "rel_has_Power_Sensor_P3"
                });
        }
    
    }
}
