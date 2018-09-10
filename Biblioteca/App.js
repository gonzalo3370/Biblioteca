import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import Filtros from './TABLAS/Filtros.js'
import PickerBox from './Pruebas/PickerBox.js'

export default class App extends React.Component {
  constructor(props){
    super(props);
    this.state = {

    }
  }
  render() {
    return (
      <View style={styles.container}>
        <Text>
         Hola Mundo
        </Text>  
        <Filtros/>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    margin: 50,
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
