import 'package:flutter/material.dart';

abstract class AppConfig {
  AppConfig();
  late final String apiUrl;
  late final String appName;
  late final Color textColor;
  late final Color textColorSecundary;
  late final CircularProgressIndicator spinnerLoading;
}
