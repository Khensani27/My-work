import { StyleSheet, Text, View, TouchableOpacity } from 'react-native';
import React from 'react';
import { colors } from '../utils/colors'; // Ensure colors are defined properly
import { useNavigation } from '@react-navigation/native';

const UserHome = ({ route }) => {
  const { user } = route.params; // Access the user object passed from LoginScreen
  const navigation = useNavigation(); // Access navigation object

  return (
    <View style={styles.container}>
      <View style={styles.card}>
        <Text style={styles.title}>Your Account Status:</Text>
        
        {/* Display only email, address, and account status */}
        <Text style={styles.infoText}><Text style={styles.label}>Email:</Text> {user.email}</Text>
        <Text style={styles.infoText}><Text style={styles.label}>Address:</Text> {user.address}</Text>
        <Text style={styles.infoText}><Text style={styles.label}>Account Status:</Text> {user.account_Status}</Text>
      </View>

      <TouchableOpacity style={styles.backButton} onPress={() => navigation.navigate('Home')}>
        <Text style={styles.backButtonText}>Back to Home</Text>
      </TouchableOpacity>
    </View>
  );
};

export default UserHome;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: colors.lightGray,
    padding: 20,
  },
  card: {
    width: '100%',
    maxWidth: 400,
    backgroundColor: colors.white,
    borderRadius: 15,
    padding: 20,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 5 },
    shadowOpacity: 0.1,
    shadowRadius: 10,
    elevation: 5,
  },
  title: {
    fontSize: 26,
    fontWeight: 'bold',
    marginBottom: 20,
    color: colors.primary,
    textAlign: 'center',
  },
  infoText: {
    fontSize: 18,
    marginBottom: 10,
  },
  label: {
    fontWeight: 'bold',
  },
  backButton: {
    marginTop: 20, // Add some space above the button
    padding: 10,
    backgroundColor: colors.primary, // Style the button background
    borderRadius: 5,
  },
  backButtonText: {
    color: colors.white, // Change the text color
    fontSize: 16,
    textAlign: 'center',
  },
});
