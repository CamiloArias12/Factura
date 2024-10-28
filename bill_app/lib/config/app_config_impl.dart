import 'package:bill_app/config/app_config.dart';
import 'package:bill_app/config/style_app/style_app.dart';
import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';

class AppConfigImpl extends AppConfig {
  late final StyleApp styleApp;

  AppConfigImpl({required super.isBackground}) {
    appName = "Gruber";
    apiUrl = const String.fromEnvironment('API_URL');
    styleApp = GetIt.I.get<StyleApp>();
    spinnerLoading = CircularProgressIndicator(color: styleApp.primaryColor);
  }
}
