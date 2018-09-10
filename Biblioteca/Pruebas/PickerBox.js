import React from 'react';
import { Picker, StyleSheet, Text, View, CheckBox } from 'react-native';

export default class App extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            Generos: [{Generos: 'Ficcion', IdGenero:1}, {Generos: 'Drama', IdGenero:2}],
            itemSeleccionado: 1,
            Texto: "Check sin seleccionar",
            checked: true
        }            
    }
    onSelecciono = (itemValue)=>{
        this.setState({
            itemSeleccionado: itemValue
        })
    }
    onChecked = ()=>{
        this.setState({
            Texto: "Seleccionado"
        })
    }
    render(){        
        let items = this.state.Generos.map((a) => {
            return <Picker.Item label = {a.Generos} value = {a.IdGenero} />;
        });         
        return (
            <View style={styles.container}>
                <Text>{this.state.Texto}</Text>
                <Picker
                    style={{height: 50, width: 200}}
                    selectedValue={this.state.itemSeleccionado}
                    onValueChange={this.onSelecciono}>
                    {items}
                </Picker>
                <CheckBox
                  title='Click Here'
                  checked={this.state.checked}
                  onPress={() => this.setState({checked: !this.state.checked})}
                />
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