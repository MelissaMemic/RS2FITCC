import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/napomena.dart';
import 'package:mobile_fitcc/Models/user.dart';
import 'package:mobile_fitcc/Providers/login_provider.dart';
import 'package:mobile_fitcc/Providers/napomena_provider.dart';
import 'package:mobile_fitcc/Providers/user_provider.dart';
import 'package:url_launcher/url_launcher.dart';

class TakmicarDetaljiScreen extends StatefulWidget {
  final User? takmicar;
  TakmicarDetaljiScreen({this.takmicar});

  @override
  _TakmicarDetaljiScreenState createState() => _TakmicarDetaljiScreenState();
}

class _TakmicarDetaljiScreenState extends State<TakmicarDetaljiScreen> {
  final _formKey = GlobalKey<FormState>();
  var _user;
  var ime;

  var userService = UserProvider();
  var loginService = LoginService();
var napomenaService=NapomenaProvider();
  final TextEditingController porukaController = TextEditingController();
  final TextEditingController napomenaController = TextEditingController();
  TextEditingController _errorMessageController = TextEditingController();
  @override
  void initState() {
    _fetchData();
  }

  @override
  void dispose() {
    porukaController.dispose();
    napomenaController.dispose();
    super.dispose();
  }
Future<void> _fetchData() async {
  var sm=  loginService.getUserName();

    setState(() {
      ime = sm;
    });
  }
  Future<void> _kontaktirajKorisnika(String? username, String? poruka)async {
    {
      var napomenaService = NapomenaProvider();
      Napomena napomena = Napomena();
          var name = LoginService().getUserName();

      napomena.userName = name;
      napomena.poruka = napomenaController.text;
      napomena.usernameTakmicar=widget.takmicar?.username;
      var response = await napomenaService.insert(napomena);

      if (response!.toJson() != null) {
        Navigator.pushNamed(context, '/pregledTakmicara');
      } else
        _errorMessageController.text = "Doslo je do greske";
    }

  }
  Future<void> _sendConfirmationEmail(String poruka) async {
    var korisnik= await userService.getUser(ime);
    final emailData = {
      'sender': 'tuttoservicech@gmail.com',
      'recipient': 'mellimostar@gmail.com',
      'subject': 'FITCC Contact proposal from ${korisnik.name} ${korisnik.lastname} ',
      'content':
          "Dear ${widget.takmicar?.username}, this is a message proposal from FITCC sponzor ${korisnik.name} ${korisnik.lastname}: ${poruka} ",
    };
    // NapomenaProvider().sendContactEmail(emailData);

    var response = await napomenaService.sendContactEmail(emailData);

      if (response) {
        Navigator.pushNamed(context, '/pregledTakmicara');
      } else
        _errorMessageController.text = "Doslo je do greske";
    
  }

  Future<void> _launchUrl(String urlString) async {
    final Uri url = Uri.parse(urlString);
    if (!await launchUrl(url)) {
      throw 'Could not launch $urlString';
    }
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold( appBar: AppBar(
        title: Text('Kontakt forma za ${widget.takmicar?.name}'), 
      ),
      body: Form(
        key: _formKey,
        child: SingleChildScrollView(
          padding: EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Text(
                  'Takmicar: ${widget.takmicar?.name} ${widget.takmicar?.lastname}'),
                  ElevatedButton(
            onPressed: () => _launchUrl('${widget.takmicar?.website ?? 'https://www.google.com'}'), 
            child: Text('CV')),
              SizedBox(height: 20),
              TextFormField(
                controller: napomenaController,
                decoration: InputDecoration(labelText: 'Napomena'),
                maxLines: 3,
              ),
              SizedBox(height: 10),
              TextFormField(
                controller: porukaController,
                decoration: InputDecoration(labelText: 'Poruka'),
                maxLines: 3,
              ),
              SizedBox(height: 20),
              ElevatedButton(
                  child: Text('Spasi napomenu'),
                  onPressed: () {
                    if (_formKey.currentState!.validate()) {
                      _kontaktirajKorisnika(widget.takmicar?.username,
                          napomenaController.text);
                    }
                  }),
                   ElevatedButton(
                  child: Text('Posalji email'),
                  onPressed: () {
                    if (_formKey.currentState!.validate()) {
                      _sendConfirmationEmail(
                          porukaController.text);
                    }
                  }),
            ],
          ),
        ),
      ),
    );
  }
}
 