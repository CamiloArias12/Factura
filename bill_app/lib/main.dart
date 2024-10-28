import 'package:bill_app/bloc/Bill/bloc.dart';
import 'package:bill_app/bloc/Client/bloc.dart';
import 'package:bill_app/service_locator.dart';
import 'package:bill_app/ui/pages/bill_page.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await serviceLocatorSetup();
  runApp(const AppManager());
}

class AppManager extends StatelessWidget {
  const AppManager({super.key});

  @override
  Widget build(BuildContext _) {
    return MultiBlocProvider(providers: [
      BlocProvider<ClientBloc>(create: (context) => GetIt.I.get<ClientBloc>()),
      BlocProvider<BillBloc>(
          create: (BuildContext context) => GetIt.I.get<BillBloc>()),
    ], child: BillPage());
  }
}
