import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Screens/Auth/login.dart';
import 'package:mobile_fitcc/Screens/home_page.dart';
import 'package:mobile_fitcc/Screens/pregled_agenda.dart';
import 'package:mobile_fitcc/Screens/pregled_projekata.dart';
import 'package:mobile_fitcc/Screens/preglet_takmicara.dart';
import 'package:mobile_fitcc/Screens/welcome_screen.dart';
import 'package:mobile_fitcc/providers/login_provider.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  MyApp({Key? key}) : super(key: key);

  @override
  var routes = {
    "/welcome": (context) => WelcomeScreen(),
    "/login": (context) => LoginScreen(),
    // "/registration": (context) => RegistrationScreen(),
    // "/takmicenjePrijava": (context) => PrijaviTimScreen(),
     "/pregledTakmicara": (context) => PregledTakmicaraScreen(),
    // "/projekatPrjava": (context) => PrijaviProjekatScreen(),
     "/pregledProjekataZiri": (context) => PregledProjekataScreen(),
    "/agendaZiriPregled": (context) => PregledAgendaScreen(),
    "/homePage": (context) => HomePage(),
    // "/profil": (context) => UserProfileScreen(),
  };

  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Welcome to Flutter',
      home: LoginService().isLoggedIn == true ? HomePage() : LoginScreen(),
      routes: routes,
    );
  }
}
