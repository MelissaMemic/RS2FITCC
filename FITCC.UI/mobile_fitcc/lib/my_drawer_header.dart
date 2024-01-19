import 'dart:ui';
import 'package:flutter/material.dart';

class MyDrawerHeader extends StatefulWidget {
  @override
  _MyHeaderDrawerState createState() => _MyHeaderDrawerState();
}

class _MyHeaderDrawerState extends State<MyDrawerHeader> {
  @override
  Widget build(BuildContext context) {
    return Container(
      color: Color.fromRGBO(33, 150, 243, 1),
      width: double.infinity,
      height: 150,
      padding: EdgeInsets.only(top: 20.0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          SizedBox(
            height: 10.0,
          ),
          Text(
            "FIT Coding Challenge",
            style: TextStyle(fontSize: 20.0),
          ),
          SizedBox(
            height: 10.0,
          ),
          // ElevatedButton(
          //   child: const Text('Moj profil'),
          //   onPressed: () {
          //     Navigator.pushNamed(context, '/pocetna-takmicar');
          //   },
          // ),
        ],
      ),
    );
  }
}
