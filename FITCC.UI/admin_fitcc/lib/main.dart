import 'package:admin_fitcc/providers/login_provider.dart';
import 'package:admin_fitcc/providers/user_provider.dart';
import 'package:admin_fitcc/screens/agendum/agendum.dart';
import 'package:admin_fitcc/screens/komisija/komisija_list.dart';
import 'package:admin_fitcc/screens/kriteriji/kriteriji_list.dart';
import 'package:admin_fitcc/screens/login_page.dart';
import 'package:admin_fitcc/screens/projekti/projekat_list.dart';
import 'package:admin_fitcc/screens/rezultati/rezultati_list.dart';
import 'package:admin_fitcc/screens/timovi/timovi_list.dart';
import 'package:admin_fitcc/screens/welcome/home_page.dart';
import 'package:admin_fitcc/screens/welcome/my_drawer_header.dart';
import 'package:flutter/material.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  MyApp({Key? key}) : super(key: key);

  @override
  var routes = {
    "/homePage": (context) => HomePage(),
    "/login": (context) => LoginScreen(),
  };
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.blue),
        useMaterial3: true,
      ),
      home: LoginService().isLoggedIn() == true ? HomePage() : LoginScreen(),
      //  home:  MyHomePage(),
      routes: routes,
    );
  }
}

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  String name = "";
  bool isAdmin = false;
  bool isTakm = false;
  var userService = UserProvider();
  var currentPage = DrawerSections.myHomePage;
  void _logout() {
    LoginService().setResponseFalse();
    Navigator.pushNamed(context, '/login');
  }

  @override
  void initState() {
    name = LoginService().getUserName();
    _fetchDataIsAdmin();
    _takmicar();
  }

  Future<void> _fetchDataIsAdmin() async {
    var something = await userService.checkRole(name, "admin");
    setState(() {
      isAdmin = something;
    });
  }
  Future<void> _takmicar() async {
    var something = await userService.checkRole(name, "takmicar");
    setState(() {
      isTakm = something;
    });
  }


  @override
  Widget build(BuildContext context) {
    var containter;
    if (currentPage == DrawerSections.myHomePage) {
      containter = PocetnaScreen();
    } else if (currentPage == DrawerSections.komisijaList) {
      containter = KomisijaList();
    } else if (currentPage == DrawerSections.projekatList) {
      containter = ProjekatList();
    } else if (currentPage == DrawerSections.dogadjajList) {
      containter = DogadjajList();
    } else if (currentPage == DrawerSections.timList) {
      containter = TimList();
    } else if (currentPage == DrawerSections.kriterijiList) {
      containter = KriterijiList();
    } else if (currentPage == DrawerSections.rezultatiList) {
      containter = RezultatiList();
    }
    return Scaffold(
      appBar: AppBar(
        title: Text(
          "FITCC",
          style: TextStyle(fontSize: 20),
        ),
        backgroundColor: Colors.black,
      ),
      body: containter,
      drawer: Drawer(
        child: SingleChildScrollView(
            child: Container(
          child: Column(
            children: [
              MyDrawerHeader(),
              MyDrawerList(),
            ],
          ),
        )),
      ),
    );
  }

  Widget MyDrawerList() {
    return Container(
      padding: EdgeInsets.only(top: 15),
      child: Column(children: [
        menuItem(
            1, "Home", currentPage == DrawerSections.myHomePage ? true : false),
        if (isTakm)
          menuItem(2, "Komisija",
              currentPage == DrawerSections.komisijaList ? true : false),
        if (isTakm)
          menuItem(3, "Projekti",
              currentPage == DrawerSections.projekatList ? true : false),
        menuItem(4, "Agendum",
            currentPage == DrawerSections.dogadjajList ? true : false),
        menuItem(
            5, "Timovi", currentPage == DrawerSections.timList ? true : false),
        if (isAdmin)
          menuItem(6, "Kriteriji",
              currentPage == DrawerSections.kriterijiList ? true : false),
        if (isAdmin)
          menuItem(7, "Rezultati",
              currentPage == DrawerSections.rezultatiList ? true : false),
        Container(
          child: TextButton(
              onPressed: () {
                _logout();
              },
              child: Text("Logout")),
        )
      ]),
    );
  }

  Widget menuItem(int id, String title, bool selected) {
    return Material(
      color: selected ? Color.fromARGB(255, 219, 243, 255) : Colors.transparent,
      child: InkWell(
        onTap: () {
          Navigator.pop(context);
          setState(() {
            if (id == 1) {
              currentPage = DrawerSections.myHomePage;
            } else if (id == 2) {
              currentPage = DrawerSections.komisijaList;
            } else if (id == 3) {
              currentPage = DrawerSections.projekatList;
            } else if (id == 4) {
              currentPage = DrawerSections.dogadjajList;
            } else if (id == 5) {
              currentPage = DrawerSections.timList;
            } else if (id == 6) {
              currentPage = DrawerSections.kriterijiList;
            } else if (id == 7) {
              currentPage = DrawerSections.rezultatiList;
            }
          });
        },
        child: Padding(
          padding: EdgeInsets.all(15.0),
          child: Row(
            children: [
              Expanded(
                  flex: 1,
                  child: Text(
                    title,
                    style: TextStyle(color: Colors.black, fontSize: 14.0),
                  ))
            ],
          ),
        ),
      ),
    );
  }
}

enum DrawerSections {
  myHomePage,
  komisijaList,
  projekatList,
  dogadjajList,
  timList,
  kriterijiList,
  rezultatiList
}
