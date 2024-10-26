import { ImageBackground, Image, StyleSheet, Text, View, TouchableOpacity } from 'react-native';
import React from 'react';
import { colors } from '../utils/colors'; // Ensure this path is correct

const HomeScreen = ({ navigation }) => {
  return (
    <ImageBackground
      source={require('../assets/test.jpg')} // Change this to your background image
      style={styles.background}
      imageStyle={styles.image} // Apply additional style to the image
    >
      <View style={styles.container}>
        <Image source={require('../assets/Logo1.jpg')} style={styles.logo} />

        <Text style={styles.welcomeText}>Welcome to Vryheid e-Library</Text>

        {/* Make sure this name matches the one defined in the App component */}
        <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Login')}>
          <Text style={styles.buttonText}>Login</Text>
        </TouchableOpacity>
        
        {/* Signup Button */}
        <TouchableOpacity style={styles.button} onPress={() => navigation.navigate('Signup')}>
          <Text style={styles.buttonText}>Sign-up</Text>
        </TouchableOpacity>
      </View>
    </ImageBackground>
  );
};

export default HomeScreen;

const styles = StyleSheet.create({
  background: {
    flex: 1,
    justifyContent: 'center', // Center content vertically
  },
  image: {
    resizeMode: 'cover', // Change this to 'cover' to fill the entire screen
  },
  container: {
    flex: 1,
    backgroundColor: 'rgba(255, 255, 255, 0.8)', // Optional: Slightly transparent background for better text visibility
    alignItems: 'center',
    justifyContent: 'center',
  },
  logo: {
    height: 175,
    width: 240,
    marginBottom: 40,
  },
  welcomeText: {
    fontSize: 22,
    fontWeight: 'bold',
    color: colors.black,
    marginBottom: 20,
    textAlign: 'center',
  },
  button: {
    backgroundColor: colors.primary,
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 10,
    marginVertical: 10,
    width: '80%',
    alignItems: 'center',
  },
  buttonText: {
    color: colors.white,
    fontSize: 16,
  },
});
