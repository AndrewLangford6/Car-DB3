using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CarInventory
{
    public partial class Form1 : Form
    {
        List<Car> carsList = new List<Car>();

        public Form1()
        {
            InitializeComponent();

            string newYear, newMake, newColour, newMileage;

            XmlReader reader = XmlReader.Create("NewFolder1/XMLFilePain.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    

                    reader.ReadToNextSibling("year");
                    newYear = reader.ReadString();

                    reader.ReadToNextSibling("make");
                    newMake = reader.ReadString();

                    reader.ReadToNextSibling("mileage");
                    newColour = reader.ReadString();

                    reader.ReadToNextSibling("colour");
                    newMileage = reader.ReadString();

                    Car newCar = new Car(newYear, newMake, newColour, newMileage);
                    carsList.Add(newCar);
                }
            }

            reader.Close();
        }


        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
             
        }
       

        private void addButton_Click(object sender, EventArgs e)
        {
            string year, make, colour, mileage;

            year = yearInput.Text;
            make = makeInput.Text;
            colour = colourInput.Text;
            mileage = mileageInput.Text;

            Car car = new Car(year, make, colour, mileage);

            carsList.Add(car);

            outputLabel.Text = "";

            //for (int i = 0; i < carsList.Count; i++)
            //{
            //    outputLabel.Text += carsList[i].year + " " + carsList[i].make + " " + carsList[i].colour + " " + carsList[i].mileage + "\n";
            //}

            foreach(Car c in carsList)
            {
                outputLabel.Text += c.year + " "
                    + c.make + " "
                    + c.colour + " "
                    + c.mileage + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void closeB_Click(object sender, EventArgs e)
        {
            XmlWriter writer = XmlWriter.Create("NewFolder1/XMLFilePain.xml", null);

            writer.WriteStartElement("cars");

            foreach (Car c in carsList)
            {
                writer.WriteStartElement("car");
                writer.WriteElementString("year", c.year);
                writer.WriteElementString("make", c.make);
                writer.WriteElementString("mileage", c.mileage);
                writer.WriteElementString("colour", c.colour);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();

            Application.Exit();
        }
    }
}
