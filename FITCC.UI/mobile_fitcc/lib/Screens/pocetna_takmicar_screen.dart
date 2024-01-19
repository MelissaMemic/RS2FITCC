import 'package:flutter/material.dart';


class PocetnaTakmicarScreen extends StatelessWidget {
  const PocetnaTakmicarScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Stack(children: <Widget>[
      Container(
        height: double.infinity,
        width: double.infinity,
        decoration: const BoxDecoration(color: Colors.black),
      ),
      Container(
          height: double.infinity,
          child: SingleChildScrollView(
              physics: AlwaysScrollableScrollPhysics(),
              padding: EdgeInsets.symmetric(horizontal: 40.0, vertical: 140.0),
              child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Center(
                      child: SizedBox(
                        child: Image.asset('assets/images/fitcc_logo.png'),
                        height: 200,
                        width: 200,
                      ),
                    ),
                    const SizedBox(
                      height: 40,
                    ),
                    Center(
                      child: Text(
                        "Dobro došli!",
                        style: TextStyle(color: Colors.white, fontSize: 55),
                      ),
                    ),
                    const SizedBox(
                      height: 40,
                    ),
                    Center(
                      child: Text(
                        "FIT Coding Challenge",
                        style: TextStyle(color: Colors.white, fontSize: 27),
                      ),
                    ),
                  ])))
    ]));
  }
}
