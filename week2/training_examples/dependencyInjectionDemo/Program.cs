IEngine sport = new Engine( "sport", 350, 6 ); // created a future dependency

Car myCar = new Car(sport); // passing our dependency (engine)

myCar.printEngineDetails();