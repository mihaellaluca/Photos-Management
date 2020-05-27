using MyPhotos.Dto;
using MyPhotos.PhotoService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyPhotosGUI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		}

		public PhotoService photoService = new PhotoService();
		private string abs_path { get; set; }
		private int index = 1;

		private void button1_Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
			{
				MessageBox.Show("Please provide all the information about the file.");
				return;
			}
			else
			{
				List<PropertyDto> newProperties = new List<PropertyDto>();
				List<PersonsDto> newPersons = new List<PersonsDto>();

				var event_name = textBox1.Text;
				var event_date = textBox2.Text;
				var event_location = textBox3.Text;
				var description = textBox4.Text;
				var created_date = DateTime.Now.ToString();

				//first property:
				var property_name = property.Text;
				var property_value = value.Text;
				var prop = new PropertyDto()
				{
					name = property_name,
					value = property_value
				};
				newProperties.Add(prop); // list of new properties

				//second property:
				var property_name2 = property2.Text;
				var property_value2 = value2.Text;
				var prop2 = new PropertyDto()
				{
					name = property_name2,
					value = property_value2
				};
				newProperties.Add(prop2); // list of new properties

				var person_fname = firstname.Text;
				var person_lname = lastname.Text;
				var person_relation = relation.Text;
				var pers = new PersonsDto()
				{
					firstname = person_fname,
					lastname = person_lname,
					relation = person_relation
				};
				newPersons.Add(pers); // list of new persons

				var request = new CreateFileDto()
				{
					abs_path = abs_path,
					created_date = created_date,
					@event = event_name,
					event_date = event_date,
					event_location = event_location,
					description = description,
					newProperties = newProperties,
					newPersons = newPersons
				};
				

				var newFile = photoService.AddNewFile(request);
				if(newFile != null)
				{
					MessageBox.Show("File inserted.");
				}
				else
				{
					MessageBox.Show("Not inserted.");
				}


			}
		}


		private void button2_Click(object sender, EventArgs e) // upload photo
		{
			OpenFileDialog opnfd = new OpenFileDialog();
			opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
			if (opnfd.ShowDialog() == DialogResult.OK)
			{
				abs_path = opnfd.FileName;
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox1.Image = new Bitmap(opnfd.FileName);
			}

		}


		private void button3_Click(object sender, EventArgs e)
		{
			OpenFileDialog opnfd = new OpenFileDialog();
			opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
			if (opnfd.ShowDialog() == DialogResult.OK)
			{
				pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox2.Image = new Bitmap(opnfd.FileName);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			TextBox txt1 = new TextBox();
			TextBox txt2 = new TextBox();
			Controls.Add(txt1);
			Controls.Add(txt2);
			txt1.Top = index * 25;
			txt1.Left = 400;
			txt2.Top = index * 25;
			txt2.Left = 500;
			txt1.Name = "newtextbox1"+ index.ToString();
			txt1.Name = "newtextbox2" + index.ToString();
			index++;
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			listView1.View = View.Details;
			listView1.Columns.Add("My photos", 350);
			listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
			
		}
		private void listView2_SelectedIndexChanged(object sender, EventArgs e)
		{
			listView2.View = View.Details;
			listView2.Columns.Add("Found files", 350);
			listView2.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		private void listView3_SelectedIndexChanged(object sender, EventArgs e)
		{
			listView3.View = View.Details;
			listView3.Columns.Add("Found files", 350);
			listView3.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void ViewAllFiles_Button_Click(object sender, EventArgs e)
		{
			viewAllFiles();
		}
		private void filterByProperty_Click(object sender, EventArgs e)
		{
			Search_By_Property();

		}
		private void button6_Click(object sender, EventArgs e)
		{
			Search_By_Relation();
		}


		private void listView1_MouseClick(object sender, MouseEventArgs e)
		{
			// a particular item on the list has been clicked
			string selected = listView1.SelectedItems[0].SubItems[0].Text;
			pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox3.Image = new Bitmap(selected);


		}
		private void listView2_MouseClick(object sender, MouseEventArgs e)
		{
			// a particular item on the list has been clicked
			string selected = listView2.SelectedItems[0].SubItems[0].Text;
			pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox3.Image = new Bitmap(selected);

		}
		private void listView3_MouseClick(object sender, MouseEventArgs e)
		{
			string selected = listView1.SelectedItems[0].SubItems[0].Text;
			pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox3.Image = new Bitmap(selected);
		}

			
		private void viewAllFiles()
		{
			listView1.Items.Clear();
			ImageList imgs = new ImageList();
			imgs.ImageSize = new Size(100, 100);
			List<string> paths = photoService.GetAllFilesPaths();
			//ppaths = Directory.GetFiles(path);
			// load images from db:
			try
			{
				foreach (string path in paths)
				{
					imgs.Images.Add(Image.FromFile(path));
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			//bind imgs to the listview:
			listView1.SmallImageList = imgs;
			for (var i = 0; i < paths.Count; i++)
			{
				listView1.Items.Add(paths[i], i);
			}
		}


		private void Search_By_Property()
		{
			var property_name = propertyNameFilter.Text;
			var property_value = propertyValueFilter.Text;
			ImageList imgs = new ImageList();
			imgs.ImageSize = new Size(100, 100);
			List<string> paths = photoService.GetFilesByProperty(property_name, property_value);
			//ppaths = Directory.GetFiles(path);
			// load images from db:
			try
			{
				if (paths.Count != 0)
					foreach (string path in paths)
					{
						imgs.Images.Add(Image.FromFile(path));
					}
				else
				{
					MessageBox.Show("There is no file with the specified property.");
				}

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			//bind imgs to the listview:
			listView2.SmallImageList = imgs;
			for (var i = 0; i < paths.Count; i++)
			{
				listView2.Items.Add(paths[i], i);
			}
		}

		private void Search_By_Relation()
		{
			var relation_type = textBox7.Text;
			ImageList imgs = new ImageList();
			imgs.ImageSize = new Size(100, 100);
			List<string> paths = photoService.GetFilesByRelation(relation_type);
			// load images from db:
			try
			{
				if (paths.Count != 0)
					foreach (string path in paths)
					{
						imgs.Images.Add(Image.FromFile(path));
					}
				else
				{
					MessageBox.Show("There is no file with specified person category.");
				}

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			//bind imgs to the listview:
			listView3.SmallImageList = imgs;
			for (var i = 0; i < paths.Count; i++)
			{
				listView3.Items.Add(paths[i], i);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{
			List<PropertyDto> modifiedProperties = new List<PropertyDto>();
			List<PersonsDto> modifiedPersons = new List<PersonsDto>();
			var abs_path = listView1.SelectedItems[0].SubItems[0].Text;
			pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox3.Image = new Bitmap(abs_path);
			var event_name = textBox13.Text;
			var event_date = textBox14.Text;
			var event_location = textBox15.Text;
			var description = textBox16.Text;
			var property_name = textBox9.Text;
			var property_value = textBox10.Text;
			
			var person_fname = textBox11.Text;
			var person_lname = textBox12.Text;
			var relation_type = textBox8.Text;


			var prop = new PropertyDto()
			{
				name = property_name,
				value = property_value
			};

			var pers = new PersonsDto()
			{
				firstname = person_fname,
				lastname = person_lname,
				relation = relation_type
			};
			modifiedProperties.Add(prop); // list of modified properties
			modifiedPersons.Add(pers); // list of modified persons

			var request = new CreateFileDto()
			{
				abs_path = abs_path,
				created_date = "",
				@event = event_name,
				event_date = event_date,
				event_location = event_location,
				description = description,
				newProperties = modifiedProperties,
				newPersons = modifiedPersons
			};

			photoService.ModifyFile(request);
			MessageBox.Show("Check if the file is modified.");


		}


/*		private void button7_Click(object sender, EventArgs e) //delete photo button
		{
			var abs_path = listView1.SelectedItems[0].SubItems[0].Text;
			photoService.DeleteFileByPath(abs_path);
			MessageBox.Show("File deleted");
		}*/
	}
}



