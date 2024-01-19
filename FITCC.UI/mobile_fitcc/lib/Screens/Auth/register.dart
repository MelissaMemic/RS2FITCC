import 'package:mobile_fitcc/constants.dart';
import 'package:flutter/material.dart';

class RegistrationScreen extends StatelessWidget {
  const RegistrationScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: <Widget>[
          Container(
            height: double.infinity,
            width: double.infinity,
            decoration: const BoxDecoration(
              image: DecorationImage(
                image: AssetImage("assets/images/space.jpg"),
                fit: BoxFit.cover,
              ),
            ),
          ),
          Container(
            child: SizedBox(
              width: 400,
              height: 70,
              child: OutlinedButton(
                style: ButtonStyle(
                  backgroundColor:
                      MaterialStateProperty.all<Color>(Colors.transparent),
                ),
                onPressed: () {
                  Navigator.pushNamed(context, '/welcome');
                },
                child: const Text(
                  'Nazad',
                  style: TextStyle(
                    color: Colors.white,
                    fontFamily: 'Montserrat',
                  ),
                ),
              ),
            ),
          ),
          Container(
            height: double.infinity,
            child: SingleChildScrollView(
                physics: AlwaysScrollableScrollPhysics(),
                padding:
                    EdgeInsets.symmetric(horizontal: 40.0, vertical: 140.0),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text(
                      "Registrujte se",
                      style: TextStyle(
                        color: kPrimaryLightColor,
                        fontSize: 30.0,
                        fontWeight: FontWeight.w500,
                        fontFamily: 'Montserrat',
                      ),
                    ),
                    SizedBox(height: 30.0),
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Text(
                          "Ime",
                          style: TextStyle(
                              color: kPrimaryLightColor,
                              fontSize: 25.0,
                              fontWeight: FontWeight.w500,
                              fontFamily: 'Montserrat'),
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Container(
                          alignment: Alignment.centerLeft,
                          decoration: kBoxDecorationStyle,
                          height: 50.0,
                          child: TextField(
                            keyboardType: TextInputType.emailAddress,
                            style: TextStyle(color: kPrimaryLightColor),
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                contentPadding: EdgeInsets.all(7.0),
                                hintText: 'Ime',
                                hintStyle: TextStyle(
                                    color: Colors.black,
                                    fontWeight: FontWeight.w300,
                                    fontFamily: 'Montserrat')),
                          ),
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Text(
                          "Prezime",
                          style: TextStyle(
                              color: kPrimaryLightColor,
                              fontSize: 25.0,
                              fontWeight: FontWeight.w500,
                              fontFamily: 'Montserrat'),
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Container(
                          alignment: Alignment.centerLeft,
                          decoration: kBoxDecorationStyle,
                          height: 50.0,
                          child: TextField(
                            keyboardType: TextInputType.emailAddress,
                            style: TextStyle(color: kPrimaryLightColor),
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                contentPadding: EdgeInsets.all(7.0),
                                hintText: 'Prezime',
                                hintStyle: TextStyle(
                                    color: Colors.black,
                                    fontWeight: FontWeight.w300,
                                    fontFamily: 'Montserrat')),
                          ),
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Text(
                          "Email adresa",
                          style: TextStyle(
                              color: kPrimaryLightColor,
                              fontSize: 25.0,
                              fontWeight: FontWeight.w500,
                              fontFamily: 'Montserrat'),
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Container(
                          alignment: Alignment.centerLeft,
                          decoration: kBoxDecorationStyle,
                          height: 50.0,
                          child: TextField(
                            keyboardType: TextInputType.emailAddress,
                            style: TextStyle(color: kPrimaryLightColor),
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                contentPadding: EdgeInsets.all(7.0),
                                hintText: 'Unesite svoju email adresu',
                                hintStyle: TextStyle(
                                    color: Colors.black,
                                    fontWeight: FontWeight.w300,
                                    fontFamily: 'Montserrat')),
                          ),
                        )
                      ],
                    ),
                    SizedBox(
                      height: 15.0,
                    ),
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Text(
                          "Lozinka",
                          style: TextStyle(
                              color: kPrimaryLightColor,
                              fontSize: 25.0,
                              fontWeight: FontWeight.w500,
                              fontFamily: 'Montserrat'),
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Container(
                          alignment: Alignment.centerLeft,
                          decoration: kBoxDecorationStyle,
                          height: 50.0,
                          child: TextField(
                            obscureText: true,
                            style: TextStyle(color: kPrimaryLightColor),
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                contentPadding: EdgeInsets.all(7.0),
                                hintText: 'Unesite svoju lozinku',
                                hintStyle: TextStyle(
                                    color: Colors.black,
                                    fontWeight: FontWeight.w300,
                                    fontFamily: 'Montserrat')),
                          ),
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Text(
                          "Institucija",
                          style: TextStyle(
                              color: kPrimaryLightColor,
                              fontSize: 25.0,
                              fontWeight: FontWeight.w500,
                              fontFamily: 'Montserrat'),
                        ),
                        SizedBox(
                          height: 15.0,
                        ),
                        Container(
                          alignment: Alignment.centerLeft,
                          decoration: kBoxDecorationStyle,
                          height: 50.0,
                          child: TextField(
                            keyboardType: TextInputType.emailAddress,
                            style: TextStyle(color: kPrimaryLightColor),
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                contentPadding: EdgeInsets.all(7.0),
                                hintText: 'Institucija',
                                hintStyle: TextStyle(
                                    color: Colors.black,
                                    fontWeight: FontWeight.w300,
                                    fontFamily: 'Montserrat')),
                          ),
                        ),
                        SizedBox(
                          height: 30.0,
                        ),
                        SizedBox(
                          width: 400,
                          height: 50,
                          child: OutlinedButton(
                            style: ButtonStyle(
                              backgroundColor: MaterialStateProperty.all<Color>(
                                  kPrimaryColor),
                            ),
                            onPressed: () {},
                            child: const Text(
                              'Dalje',
                              style: TextStyle(color: Colors.white),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ],
                )),
          )
        ],
      ),
    );
  }
}
