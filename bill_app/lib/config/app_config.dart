import 'package:flutter/material.dart';

abstract class AppConfig {
  AppConfig({required this.isBackground});
  late final String apiUrl;
  late final String appName;
  late final String googleMapsApiKey;
  late final bool isBackground;

  late final String milesSeparator;
  late final String decimalSeparator;

  late final int periodicGPSLocationSec;

  late final Color textColor;
  late final Color textColorSecundary;
  late final CircularProgressIndicator spinnerLoading;
}
