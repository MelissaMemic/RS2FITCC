import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/auth_request.dart';
import 'package:mobile_fitcc/Models/auth_response.dart';
import 'package:mobile_fitcc/Providers/login_provider.dart';
import 'package:mobile_fitcc/constants.dart';


class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _formKey = GlobalKey<FormState>();
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  TextEditingController _errorMessageController = TextEditingController();

  Future<void> _login() async {
    {
      var authService = LoginService();
      AuthResponse? response = await authService.loginAction(
          AuthRequest(_usernameController.text, _passwordController.text));
      if (response!.result) {
        Navigator.pushNamed(context, '/homePage');
      } else
        _errorMessageController.text = "Korisnicko ime ili lozinka pogresni";
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Form(
      key: _formKey,
      child: Stack(
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
            height: double.infinity,
            child: SingleChildScrollView(
                physics: AlwaysScrollableScrollPhysics(),
                padding:
                    EdgeInsets.symmetric(horizontal: 40.0, vertical: 140.0),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text(
                      "Prijavite se",
                      style: TextStyle(
                        color: kPrimaryLightColor,
                        fontSize: 30.0,
                        fontWeight: FontWeight.w500,
                        fontFamily: 'Montserrat',
                      ),
                    ),
                    SizedBox(height: 40.0),
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Text(
                          "Korisnicko ime",
                          style: TextStyle(
                              color: kPrimaryLightColor,
                              fontSize: 25.0,
                              fontWeight: FontWeight.w500,
                              fontFamily: 'Montserrat'),
                        ),
                        SizedBox(
                          height: 10.0,
                        ),
                        Container(
                          alignment: Alignment.centerLeft,
                          decoration: kBoxDecorationStyle,
                          height: 60.0,
                          child: TextFormField(
                            controller: _usernameController,
                            keyboardType: TextInputType.emailAddress,
                            style: TextStyle(color: Colors.black),
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                contentPadding: EdgeInsets.all(7.0),
                                hintText: 'Unesite svoje korisnicko ime',
                                hintStyle: TextStyle(
                                    color: Colors.black,
                                    fontWeight: FontWeight.w300,
                                    fontFamily: 'Montserrat')),
                            validator: (value) {
                              if (value == null || value.isEmpty) {
                                return 'Unesite email adresu';
                              }
                            },
                          ),
                        )
                      ],
                    ),
                    SizedBox(height: 30.0),
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
                          height: 10.0,
                        ),
                        Container(
                          alignment: Alignment.centerLeft,
                          decoration: kBoxDecorationStyle,
                          height: 60.0,
                          child: TextFormField(
                            obscureText: true,
                            controller: _passwordController,
                            style: TextStyle(color: Colors.black),
                            decoration: InputDecoration(
                                border: InputBorder.none,
                                contentPadding: EdgeInsets.all(7.0),
                                hintText: 'Unesite svoju lozinku',
                                hintStyle: TextStyle(
                                  color: Colors.black,
                                  fontWeight: FontWeight.w300,
                                  fontFamily: 'Montserrat',
                                )),
                            validator: (value) {
                              if (value == null || value.isEmpty) {
                                return 'Unesite lozinku';
                              }
                            },
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
                            onPressed: () {
                              if (_formKey.currentState!.validate()) {
                                _login();
                              }
                            },
                            child: const Text(
                              'Dalje',
                              style: TextStyle(color: Colors.white),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: 30.0,
                        ),
                      ],
                    ),
                  ],
                )),
          )
        ],
      ),
    ));
  }
}
