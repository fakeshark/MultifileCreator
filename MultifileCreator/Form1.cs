using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MultifileCreator
{
    public partial class frmFileCreator : Form
    {
        string file_name = "";
        string folderPath = "";
        string placeHolderTMNO = "";
        string placeHolderNAME = "";
        string placeHolderPARTNO = "";
        string placeHolderFSC = "";
        string placeHolderNIIN = "";
        string placeHolderGHGDATE = "";
        string placeHolderDATE = "";
        string placeHolderMODELNO = "";
        string placeHolderCHGDATE = "";
        
        public frmFileCreator()
        {
            InitializeComponent();
        }

        private void btnAdd_UpdateFile_Click(object sender, EventArgs e)
        {
            //  Todo:
            //  Check if Name already exists in list

            if (txtFileNameEntry.Text != "" && txtFileNameEntry.Text != null)
            {
                file_name = txtFileNameEntry.Text;
                DoesNameExist(file_name);
            }

        }

        private void btnAdd_UpdateFile_Enter()
        {
            //  Todo:
            //  Check if Name already exists in list

            if (txtFileNameEntry.Text != "" && txtFileNameEntry.Text != null)
            {
                file_name = txtFileNameEntry.Text;
                DoesNameExist(file_name);
            }

        }

        void AddUpdateFileName(string file_name)
        {
            if (btnAdd_UpdateFile.Tag == "AddFile")
            {
                // adds filename to bottom of list
                lbxFileListBox.Items.Add(file_name);
                // update the qty of items currently on list
                UpdateListFileQty();
                // return focus to text box for next entry
                txtFileNameEntry.Focus();
            }
            else
            {
                // perform update of selected list item

                MessageBox.Show("Name updated!", "File Name Update");
                // update the qty of items currently on list
                UpdateListFileQty();
                //  return button color to normal
                btnAdd_UpdateFile.BackColor = Color.Linen;
                //  return button tag to normal
                btnAdd_UpdateFile.Tag = "AddFile";
                //  return button text to normal
                btnAdd_UpdateFile.Text = "Add File to List ▼";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //  close program
            this.Close();
        }

        private void UpdateListFileQty()
        {
            // update the qty of items currently on list
            lblFileQty.Text = "Number of Files: " + Convert.ToString(lbxFileListBox.Items.Count);
        }

        private void DoesNameExist(string file_name)
        {
            // Check to see if name is already on list
            if (!lbxFileListBox.Items.Contains(file_name))
            {
                AddUpdateFileName(file_name); 
            }
            else
            {
                //  Tells user that name is already used
                MessageBox.Show("This file name already exists in the file listing.", "Duplicate File Name");
                //  selects the text in the filename textbox
                txtFileNameEntry.SelectAll();
                //  puts focus back to textbox so user can fix duplicate name
                txtFileNameEntry.Focus();
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            //  Removes selected item from list
           lbxFileListBox.Items.Remove(lbxFileListBox.SelectedItem);
            //  Updates list qty
           UpdateListFileQty();
        }

        private void btnMoveFileUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void btnMoveFileDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void MoveItem(int direction)
        {
            // Checking selected item
            if (lbxFileListBox.SelectedItem == null || lbxFileListBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = lbxFileListBox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= lbxFileListBox.Items.Count)
                return; // Index out of range - nothing to do

            object selected = lbxFileListBox.SelectedItem;

            // Removing removable element
            lbxFileListBox.Items.Remove(selected);
            // Insert it in new position
            lbxFileListBox.Items.Insert(newIndex, selected);
            // Restore selection
            lbxFileListBox.SetSelected(newIndex, true);
        }

        private void btnEditFileName_Click(object sender, EventArgs e)
        {
            EditFileName();
        }

        private void EditFileName()
        {
            // Checking selected item
            if (lbxFileListBox.SelectedItem == null || lbxFileListBox.SelectedIndex < 0)
            {
                return; // No selected item - nothing to do
            }
            else
            {
                //  Change button text from 'Add' to 'Update' 
                btnAdd_UpdateFile.Text = "Update File Name";

                //  change button color too
                btnAdd_UpdateFile.BackColor = Color.Bisque;
                //  change button tag to UpdateFile
                btnAdd_UpdateFile.Tag = "UpdateFile";

                //  Copy text of selected item into textbox for editing
                txtFileNameEntry.Text = lbxFileListBox.GetItemText(lbxFileListBox.SelectedItem);
                //  move focus to textbox
                txtFileNameEntry.Focus();

                //  Check if file name already exists on list

                //  change selected item to reflect new file name
            }
        }

        public void btnMakeFiles_Click(object sender, EventArgs e)
        {
            if (folderPath != "")
            {
                string frontMatterContent = "<paper.frnt>\n" +
"\t<frntcover>\n\t\t<tmtitle>\n" +
"\t\t\t<tmno>" + placeHolderTMNO + "</tmno>\n" +
"\t\t\t<prtitle>\n" +
"\t\t\t\t<sysnomen>\n" +
"\t\t\t\t\t<name>" + placeHolderNAME + "</name>\n" +
"\t\t\t\t\t<modelno>" + placeHolderMODELNO + "</modelno>\n" +
"\t\t\t\t\t<partno>" + placeHolderPARTNO + "</partno>\n" +
"\t\t\t\t\t<nsn>\n" +
"\t\t\t\t\t\t<fsc>" + placeHolderFSC + "</fsc>\n" +
"\t\t\t\t\t\t<niin>" + placeHolderNIIN + "</niin>\n" +
"\t\t\t\t\t</nsn>\n" +
"\t\t\t\t</sysnomen>\n" +
"\t\t\t</prtitle>\n" +
"\t\t</tmtitle>\n" +
"\t\t<graphic boardno=\"G00000000000\"></graphic>\n" +
"\t\t<notices>\n" +
"\t\t\t<dist>" +
"\t\t\t\t<a.statement/>\n" +
"\t\t\t</dist>" +
"\t\t</notices>" +
"\t\t<servnomen>HEADQUARTERS, DEPARTMENT OF THE ARMY</servnomen>" +
"\t\t<date>" + placeHolderDATE + "</date>" +
"\t</frntcover>" +
"\t<warnsum id=\"warnSum-10-00001\" tocentry=\"1\">" +
"\t\t<para>This warning summary contains general safety warnings and hazardous material warnings that must be understood and applied during operation and maintenance of this equipment. Failure to observe these precautions could result in serious injury or death to personnel.</para>" +
"\t\t<first_aid>" +
"\t\t\t<title>FIRST AID DATA</title>" +
"\t\t\t<para>For first aid treatment, refer to <extref docno=\"TC 4-02.1\" />.</para>" +
"\t\t</first_aid>" +
"\t\t<safety>" +
"\t\t\t<title>Explanation of Safety Warning Icons</title>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Ear_Protection_Symbol\"/>" +
"\t\t\t\t\t<sftydesc>" +
"\t\t\t\t\t\t<title>EAR PROTECTION</title>" +
"\t\t\t\t\t\t<text>Headphones over ears show that noise level will harm ears.</text>" +
"\t\t\t\t\t</sftydesc>" +
"\t\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Electrical-hand\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>ELECTRICAL</title>" +
"\t\t\t\t\t<text>Electrical wire to hand with electricity symbol running through hand shows that shock hazard is present.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Electrical_Symbols\"/>" +
"\t\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>ELECTRICAL</title>" +
"\t\t\t\t\t<text>Electrical wire to arm with electricity symbol running through human body shows that shock hazard is present.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Falling_Parts\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>FALLING PARTS</title>" +
"\t\t\t\t\t<text>Arrow bouncing off human shoulder and head shows that falling parts present a danger to life or limb.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Flying_Particles_wShield\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>FLYING PARTICLES</title>" +
"\t\t\t\t\t<text>Arrows bouncing off face shield show that particles flying through the air will harm face.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Heavy_Object\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>HEAVY OBJECT</title>" +
"\t\t\t\t\t<text>Human figure stooping over heavy object shows physical injury potential from improper lifting technique.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Heavy_Parts-above\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title >HEAVY PARTS</title>" +
"\t\t\t\t\t<text>Heavy object on human figure shows that heavy parts present a danger to life or limb.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Heavy_Parts-foot\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>HEAVY PARTS</title>" +
"\t\t\t\t\t<text>Foot with heavy object on top shows that heavy parts can crush and harm.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Heavy_Parts-hand\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>HEAVY PARTS</title>" +
"\t\t\t\t\t<text>Hand with heavy object on top shows that heavy parts can crush and harm.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Heavy_Parts-wall\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>HEAVY PARTS</title>" +
"\t\t\t\t\t<text>Heavy object pinning human figure against wall shows that heavy, moving parts present a danger to life or limb.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Helmet_Protection\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title >HELMET PROTECTION</title>" +
"\t\t\t\t\t<text>Arrow bouncing off head with helmet shows that falling parts present a danger.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Hot_Area\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>HOT AREA</title>" +
"\t\t\t\t\t<text>Hand over object radiating heat shows that part is hot and can burn. Hand over object radiating heat shows that part is hot and can burn.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons><symbol boardno=\"Laser_Light\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>LASER LIGHT</title>" +
"\t\t\t\t\t<text>Laser light hazard symbol indicates extreme danger for eyes from laser beams and reflections.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Moving_Parts-arm\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>MOVING PARTS</title>" +
"\t\t\t\t\t<text>Human figure with arm caught between gears shows that the moving parts of the equipment present a danger to life or limb.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Moving_Parts-fingers\"/>" +
"\t\t\t\t\t<sftydesc>" +
"\t\t\t\t\t\t<title>MOVING PARTS</title>" +
"\t\t\t\t\t\t<text>Hand with fingers caught between gears shows that the moving parts of the equipment present a danger to life or limb.</text>" +
"\t\t\t\t\t</sftydesc>" +
"\t\t\t\t</sfty-icons>" +
"\t\t\t\t<sfty-icons>" +
"\t\t\t\t\t<symbol boardno=\"Moving_Parts-rollers\"/>" +
"\t\t\t\t\t<sftydesc>" +
"\t\t\t\t\t\t<title>MOVING PARTS</title>" +
"\t\t\t\t\t\t<text>Hand with fingers caught between rollers shows that the moving parts of the equipment present a danger to life or limb.</text>" +
"\t\t\t\t\t</sftydesc>" +
"\t\t\t\t</sfty-icons>" +
"\t\t\t\t<sfty-icons>" +
"\t\t\t\t\t<symbol boardno=\"Sharp_Object-foot\"/>" +
"\t\t\t\t\t<sftydesc>" +
"\t\t\t\t\t\t<title>SHARP OBJECT</title>" +
"\t\t\t\t\t\t<text>Pointed object in foot shows that a sharp object presents a danger to limb.</text>" +
"\t\t\t\t\t</sftydesc>" +
"\t\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Sharp_Object-in_hand\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title >SHARP OBJECT</title>" +
"\t\t\t\t\t<text>Pointed object in hand shows that a sharp object presents a danger to limb.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Sharp_Object-puncture\"/>" +
"\t\t\t\t\t<sftydesc>" +
"\t\t\t\t\t\t<title>SHARP OBJECT</title>" +
"\t\t\t\t\t\t<text>Pointed object in hand shows that a sharp object presents a danger to limb.</text>" +
"\t\t\t\t\t</sftydesc>" +
"\t\t\t\t</sfty-icons>" +
"\t\t\t<sfty-icons>" +
"\t\t\t\t<symbol boardno=\"Slick_Floor\"/>" +
"\t\t\t\t<sftydesc>" +
"\t\t\t\t\t<title>SLICK FLOOR</title>" +
"\t\t\t\t\t<text>Wavy line on floor with legs prone shows that slick floor presents a danger for falling.</text>" +
"\t\t\t\t</sftydesc>" +
"\t\t\t</sfty-icons>" +
"\t\t</safety>" +
"\t\t<warninfo>" +
"\t\t\t<title>GENERAL SAFETY WARNING DESCRIPTIONS</title>" +
"\t\t\t<warning>" +
"\t\t\t\t<icon-set boardno=\"Ear_Protection_Symbol\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Electrical-hand\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Electrical_Symbols\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Falling_Parts\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Flying_Particles_wShield\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Heavy_Object\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Heavy_Parts-above\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Heavy_Parts-foot\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Heavy_Parts-hand\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Heavy_Parts-wall\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Helmet_Protection\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Hot_Area\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Laser_Light\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Moving_Parts-arm\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Moving_Parts-fingers\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Moving_Parts-rollers\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Sharp_Object-foot\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Sharp_Object-in_hand\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Sharp_Object-puncture\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Slick_Floor\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Biological_Symbol\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Chemical\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Cryogenic_Symbol\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Explosion\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Eye_Protection\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Fire\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Poison\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Radiation\"/>" +
"\t\t\t\t\t<icon-set boardno=\"Vapor\"/>" +
"\t\t\t\t<trim.para>General safety warning descriptions go here.</trim.para>" +
"\t\t\t</warning>" +
"\t\t</warninfo>" +
"\t\t<hazmat>" +
"\t\t\t<title>EXPLANATION OF HAZARDOUS MATERIALS ICONS</title>" +
"\t\t\t<haz-icons>" +
"\t\t\t\t<symbol boardno=\"Biological_Symbol\"/>" +
"\t\t\t\t<hazdesc>" +
"\t\t\t\t\t<title>BIOLOGICAL</title>" +
"\t\t\t\t\t<text>Abstract symbol bug shows that a material may contain bacteria or viruses that present a danger to life or health.</text>" +
"\t\t\t\t</hazdesc>" +
"\t\t\t</haz-icons>" +
"\t\t\t<haz-icons>" +
"\t\t\t\t<symbol boardno=\"Chemical\"/>" +
"\t\t\t\t<hazdesc>" +
"\t\t\t\t\t<title>CHEMICAL</title>" +
"\t\t\t\t\t<text>Drops of liquid on hand shows that the material will cause burns or irritation to human skin or tissue.</text>" +
"\t\t\t\t</hazdesc>" +
"\t\t\t</haz-icons>" +
"\t\t\t<haz-icons>" +
"\t\t\t\t<symbol boardno=\"Explosion\"/>" +
"\t\t\t\t<hazdesc>" +
"\t\t\t\t\t<title>EXPLOSION</title>" +
"\t\t\t\t\t<text>Rapidly expanding symbol shows that the material may explode if subjected to high temperatures, sources of ignition, or high pressure.</text>" +
"\t\t\t\t</hazdesc>" +
"\t\t\t</haz-icons>" +
"\t\t\t<haz-icons>" +
"\t\t\t\t<symbol boardno=\"Eye_Protection\"/>" +
"\t\t\t\t<hazdesc>" +
"\t\t\t\t\t<title>EYE PROTECTION</title>" +
"\t\t\t\t\t<text>Person with goggles shows that the material will injure the eyes.</text>" +
"\t\t\t\t</hazdesc>" +
"\t\t\t</haz-icons>" +
"\t\t\t<haz-icons>" +
"\t\t\t\t<symbol boardno=\"Fire\"/>" +
"\t\t\t\t<hazdesc>" +
"\t\t\t\t\t<title>FIRE</title>" +
"\t\t\t\t\t<text>Flame shows that a material may ignite and cause burns.</text>" +
"\t\t\t\t</hazdesc>" +
"\t\t\t</haz-icons>" +
"\t\t\t<haz-icons>" +
"\t\t\t\t<symbol boardno=\"Poison\"/>" +
"\t\t\t\t<hazdesc>" +
"\t\t\t\t\t<title>POISON</title>" +
"\t\t\t\t\t<text>Skull and crossbones shows that a material is poisonous or is a danger to life.</text>" +
"\t\t\t\t</hazdesc>" +
"\t\t\t</haz-icons>" +
"\t\t\t<haz-icons>" +
"\t\t\t\t<symbol boardno=\"Vapor\"/>" +
"\t\t\t\t<hazdesc>" +
"\t\t\t\t\t<title>VAPOR</title>" +
"\t\t\t\t\t<text>Human figure in a cloud shows that material vapors present a danger to life or health.</text>" +
"\t\t\t\t</hazdesc>" +
"\t\t\t</haz-icons>" +
"\t\t\t<title>GENERAL HAZARDOUS MATERIALS DESCRIPTION</title>" +
"\t\t\t<hazard>" +
"\t\t\t\t<hazid>WORK SAFETY</hazid>" +
"\t\t\t\t<symbol boardno=\"Vapor\"/>" +
"\t\t\t\t<symbol boardno=\"Chemical\"/>" +
"\t\t\t\t<para>Improper cleaning methods and use of unauthorized cleaning liquids or solvents can result in breathing harmful chemicals causing injury or death to personnel.</para>" +
"\t\t\t\t<para>If personnel become light-headed while using cleaning solvent, immediately get fresh air and medical help. If solvent contacts eyes, immediately wash eyes and get medical attention. Failure to comply may result in injury or death to personnel.</para>" +
"\t\t\t</hazard>" +
"\t\t\t<hazard>" +
"\t\t\t\t<hazid>BATTERIES</hazid>" +
"\t\t\t\t<symbol boardno=\"Chemical\"/>" +
"\t\t\t\t<symbol boardno=\"Explosion\"/>" +
"\t\t\t\t<symbol boardno=\"Vapor\"/>" +
"\t\t\t\t<para>Always check electrolyte level with engine stopped. Do not smoke or use exposed flame when checking batteries; explosive gases are present and serious injury or death to personnel can occur.</para>" +
"\t\t\t\t<para>Battery acid is extremely harmful. Always wear face shield and rubber gloves, and do not smoke when performing maintenance on batteries. Injury will result if acid contacts skin or eyes. Wear full personal protective equipment to prevent injuries to skin. Failure to comply may result in injury or death to personnel.</para>" +
"\t\t\t</hazard>" +
"\t\t\t<hazard>" +
"\t\t\t\t<hazid>HAZARDOUS WASTE DISPOSAL</hazid>" +
"\t\t\t\t<symbol boardno=\"Chemical\"/>" +
"\t\t\t\t<symbol boardno=\"Explosion\"/>" +
"\t\t\t\t<symbol boardno=\"Eye_Protection\"/>" +
"\t\t\t\t<symbol boardno=\"Poison\"/>" +
"\t\t\t\t<symbol boardno=\"Vapor\"/>" +
"\t\t\t\t<para>When servicing this equipment, performing maintenance, or disposing of materials such as engine coolant, transmission fluid, lubricants, battery acids or batteries, consult your Unit/Local Hazardous Waste Disposal Center or safety office for local regulatory guidance. If further information is needed, please contact the Army Environmental Hotline at 1-800-872-3845 (DSN 584-1699). Failure to comply may result in injury or death to personnel.</para>" +
"\t\t\t</hazard>" +
"\t\t\t<hazard>" +
"\t\t\t\t<hazid>DRYCLEANING SOLVENT</hazid>" +
"\t\t\t\t<symbol boardno=\"Chemical\"/>" +
"\t\t\t\t<symbol boardno=\"Eye_Protection\"/>" +
"\t\t\t\t<symbol boardno=\"Fire\"/>" +
"\t\t\t\t<symbol boardno=\"Poison\"/>" +
"\t\t\t\t<symbol boardno=\"Vapor\"/>" +
"\t\t\t\t<para>Dry cleaning solvent MIL-PRF-680 Type III is an environmentally compliant material. However, it may be irritating to the eyes and skin. The use of protective gloves and face shield is required. Use only in well ventilated areas. Keep away from open flames and other sources of ignition. Failure to comply may result in injury or death to personnel.</para>" +
"\t\t\t\t<para>Dry cleaning solvent P-D-680 is toxic and flammable. Always wear protective gloves and face shield, and use only in well ventilated area. Avoid contact with skin, eyes, and clothes, and do not breathe vapors. Do not use near open flame or excessive heat. The flash point of the solvent is 100&deg;F-138&deg;F (38&deg;C-59&deg;C). If personnel become light-headed while using cleaning solvent, immediately wash eyes and seek medical attention. Failure to comply may result in serious injury or death to personnel.</para>" +
"\t\t\t</hazard>" +
"\t\t</hazmat>" +
"\t</warnsum>" +
"\t<loepwp>" +
"\t\t<title>LIST OF EFFECTIVE PAGES/WORK PACKAGES</title>" +
"\t\t<note>" +
"\t\t\t<trim.para>Zero in the \"Change No.\" column indicates an original page or work package.</trim.para>" +
"\t\t</note>" +
"\t\t<issuechg>" +
"\t\t\t<trim.para>Date of issue for the original manual is:</trim.para>" +
"\t\t\t<issued>" +
"\t\t\t\t<chgno>Original Draft</chgno>" +
"\t\t\t\t<chgdate julian=\"2457555\">" + placeHolderCHGDATE + "</chgdate>" +
"\t\t\t</issued>" +
"\t\t</issuechg>" +
"\t\t<totalnumberof>" +
"\t\t\t<text>THE TOTAL NUMBER OF PAGES FOR FRONT AND REAR MATTER IS</text>" +
"\t\t\t<totnum.frnt-rear-pages></totnum.frnt-rear-pages>" +
"\t\t\t<text> AND THE TOTAL NUMBER OF WORK PACKAGES IS </text>" +
"\t\t\t<totnum.wps></totnum.wps>" +
"\t\t\t<text>CONSISTING OF THE FOLLOWING:</text>" +
"\t\t</totalnumberof>" +
"\t\t<col.titles> Page / WP No. </col.title>" +
"\t\t<col.title>ChangeNo.</col.title>" +
"\t\t<chghistory modified=\"none\">" +
"\t\t\t<pageno></pageno>" +
"\t\t\t<chgno></chgno>" +
"\t\t</chghistory>" +
"\t\t<chghistory>" +
"\t\t\t<wpno wpref=\"G00001\"/>" +
"\t\t\t<wppages></wppages>" +
"\t\t\t<chgno>0</chgno>" +
"\t\t</chghistory>" +
"\t</loepwp>" +
"\t<titleblk>" +
"\t\t<servnomen>HEADQUARTERS, DEPARTMENT OF THE ARMY</servnomen>" +
"\t\t<city>WASHINGTON</city>" +
"\t\t<state>D.C.</state>" +
"\t\t<date julian=\"2457692\">" + placeHolderDATE + "</date>" +
"\t\t<prtitle>" +
"\t\t\t<sysnomen>" +
"\t\t\t\t<name>" + placeHolderNAME + "</name>" +
"\t\t\t\t<modelno>" + placeHolderMODELNO + "</modelno>" +
"\t\t\t\t<partno>" + placeHolderPARTNO + "</partno>" +
"\t\t\t\t<nsn>" +
"\t\t\t\t\t<fsc>" + placeHolderFSC + "</fsc>" +
"\t\t\t\t\t<niin>" + placeHolderNIIN + "</niin>" +
"\t\t\t\t</nsn>" +
"\t\t\t</sysnomen>" +
"\t\t</prtitle>" +
"\t\t<reporting>" +
"\t\t\t<title>REPORTING ERRORS AND RECOMMENDING IMPROVEMENTS</title>" +
"\t\t\t<para></para>" +
"\t\t\t<reporting.para service=\"army\">You can help improve this publication. If you find any errors, or if you would like to recommend any improvements to the procedures in this publication, please let us know. The preferred method is to submit your DAForm 2028 (Recommended Changes to Publications and Blank Forms) through the Internet on the TACOM Unique Logistics Support Applications (TULSA) Web site. The Internet address is https://tulsa.tacom.army.mil.access to all applications requires CAC authentication, and you must complete the Access Request form the first time you use it. The DA Form 2028 is located under the TULSA Applications on the left-hand navigation bar. Fill out the form and click on SUBMIT. Using this form on the TULSA Web site will enable us to respond more quickly to your comments and to better manage the DA Form 2028 program. You may also mail, e-mail, or fax your comments or DA Form 2028 directly to the U.S. Army TACOM Life Cycle Management Command. The postal mail address is U.S.Army TACOM Life Cycle Management Command, ATTN: AMSTA-LCL-MPP/TECHPUBS, MS 727, 6501 E. 11 Mile Road, Warren, MI 48397-5000. The e-mail address is <internet><emailaddress=\"tacomlcmc.daform2028@us.army.mil\"/></internet>. The fax number is DSN 786-1856 or Commercial (586) 282-1856. A reply will be furnished to you.</reporting.para>" +
"\t\t\t<para></para>" +
"\t\t</reporting>" +
"\t\t<notices>" +
"\t\t\t<dist>" +
"\t\t\t\t<a.statement/>" +
"\t\t\t</dist>" +
"\t\t</notices>" +
"\t</titleblk>" +
"\t<contents>" +
"\t\t<title></title>" +
"\t\t<col.title>WP Sequence No.</col.title>" +
"\t\t<col.title>Page No.</col.title>" +
"\t\t<contententry>" +
"\t\t\t<title></title>" +
"\t\t</contententry>" +
"\t</contents>" +
"\t<howtouse>" +
"\t\t<title></title>" +
"\t\t<para0>" +
"\t\t\t<title>HOW TO OBTAIN TECHNICAL MANUALS</title>" +
"\t\t\t<para>When a new system is introduced to the Army inventory, it is the responsibility of the receiving units to notify and inform the Unit Publications Clerk that a Technical Manual is available for the new system. Throughout the life cycle of the new system, the Publications Proponent will also provide updates and changes to the Technical Manual.</para>" +
"\t\t\t<para>To receive new Technical Manuals or change packages to fielded Technical Manuals, provide the Unit Publications Clerk the full Technical Manual number, title, date of publication, and number of copies required. The Unit Publications Clerk will justify the request through the Unit Publications Officer. When the request is approved, DA Form 12-R is used to order the series of Technical Manuals from the Army Publishing Directorate (APD). Obtain the form and request a publications account from the APD Web site at <internet><homepageuri=\"http://www.apd.army.mil\"/></internet>. Once on the Website, click on the \"Orders/Subscriptions/Reports\" tab. From the drop-down menu, select \"Establish an Account,\" then select \"Tutorial\" and follow the instructions in the tutorial presentation.</para>" +
"\t\t\t<para>Complete information for obtaining Army publications can be found in <extref docno=\"DA PAM 25-33\"/>.</para>" +
"\t\t</para0>" +
"\t\t<para0>" +
"\t\t\t<title>HOW TO USE THIS MANUAL</title>" +
"\t\t\t<para>In this manual, primary chapters appear in uppercase/capital letters; work packages are presented in numeric sequence, e.g., 0001, 0002; paragraphs within a work package are not numbered and are presented in a titled format. For a first level paragraph, titles are in all upper case/capital letters, e.g., FRONT MATTER. Subordinate paragraph titles will have the first letter of the first word of each principle word all upper case/capital letters, e.g., Manual Organization and Page Numbering System. The location of additional material that must be referenced is clearly marked. Illustrations supporting maintenance procedures/text are located underneath, or as close as possible to, their referenced paragraph.</para>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>FRONT MATTER</title>" +
"\t\t\t\t<para>Front matter consists of front cover, warning summary, title block, table of contents, and how to use this manual pages.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>CHAPTER 1 - GENERAL INFORMATION, EQUIPMENT DESCRIPTION, AND THEORY OF OPERATION</title>" +
"\t\t\t\t<para>Chapter 1 Contains introductory information on the MODULAR CATASTROPHIC RECOVERY SYSTEM (MCRS) and its associated equipment, as well as equipment description and data and theory of operation.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>CHAPTER 2 - OPERATOR INSTRUCTIONS</title>" +
"\t\t\t\t<para>Chapter 2 contains preparation for use information, operating information for usual and unusual conditions, and controls and indicators.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>CHAPTER 3 - TROUBLESHOOTING PROCEDURES</title>" +
"\t\t\t\t<para>Chapter 3 contains the troubleshooting index and individual troubleshooting procedure work packages.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>CHAPTER 4 - PMCS MAINTENANCE INSTRUCTIONS</title>" +
"\t\t\t\t<para>Chapter 4 provides crew level and maintainer level PMCS procedures.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>CHAPTER 5 - CREW MAINTENANCE INSTRUCTIONS</title>" +
"\t\t\t\t<para>Chapter 5 provides crew level maintenance procedures, including general and specific MCRS item maintenance.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>CHAPTER 6 - MAINTAINER MAINTENANCE INSTRUCTIONS</title>" +
"\t\t\t\t<para>Chapter 6 provides maintainer level maintenance procedures, including general and specific MCRS item maintenance.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>CHAPTER 7 - PARTS INFORMATION</title>" +
"\t\t\t\t<para>Chapter 7 contains parts information, including illustrated parts breakdowns and companion parts listings. This is where you will find the Repair Parts and Special Tools List (RPSTL) with part number and NSN indexes.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>CHAPTER 8 - SUPPORTING INFORMATION</title>" +
"\t\t\t\t<para>Chapter 8 contains references, the maintenance allocation chart (MAC), components of end items and basic issue items (COEI/BII), additional authorization list (AAL), the expendable and durable items List, tool identification list, and mandatory replacement parts list.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>REAR MATTER</title>" +
"\t\t\t\t<para>Rear matter consists of alphabetical index, DA Form 2028, authentication page, and back cover.</para>" +
"\t\t\t</subpara1>" +
"\t\t</para0>" +
"\t\t<para0>" +
"\t\t\t<title>Manual Organization and Page Numbering System</title>" +
"\t\t\t<para>The manual is divided into five major chapters that detail the topics mentioned above. Within each chapter are work packages covering a wide range of topics. Each work package is numbered sequentially starting at page 1. The work package has its own page numbering scheme and is independent of the page numbering used by other work packages. Each page of a work package has a page number of the form X-YY where X is the work package number (e.g. 0010 is work package 10) and YY represents the number of the page within that work package. A page number such as 0010-1/blank means that page 1 contains information but page 2 of that work package has been intentionally left blank.</para>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>Finding Information</title>" +
"\t\t\t\t<para>The table of contents permits the reader to find information in the manual quickly. The reader should start here when looking for a specific topic. The table of contents lists the topics, figures, and tables contained within each chapter and the work package sequence number where it can be found.</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>Example:</title>" +
"\t\t\t\t<para>If the reader were looking for information about the purpose of the Modular Catastrophic Recovery System (MCRS), which is a general information topic, the table of contents indicates that general information can be found in chapter 1. Scanning down the listings for chapter 1, information on the purpose of the MCRS can be found in <xref wpid=\"G00001\"/>, General Information. (i.e. Work Package 01).</para>" +
"\t\t\t</subpara1>" +
"\t\t\t<subpara1>" +
"\t\t\t\t<title>Alphabetical Index</title>" +
"\t\t\t\t<para>An Alphabetical Index can be found at the back of the manual; specific topics are listed with the corresponding work package number.</para>" +
"\t\t\t</subpara1>" +
"\t\t</para0>" +
"\t</howtouse>" +
"</paper.frnt>\n";
                foreach (string filename in lbxFileListBox.Items)
                {
                    string path = @folderPath + "\\" + filename + ".txt";

                    if (!File.Exists(path))
                    {
                        File.Create(path).Dispose();
                        using (TextWriter tw = new StreamWriter(path))
                        {
                            tw.WriteLine(frontMatterContent);
                            tw.Close();
                        }
                    }
                    else if (File.Exists(path))
                    {
                        using (TextWriter tw = new StreamWriter(path))
                        {
                            tw.WriteLine(frontMatterContent);
                            tw.Close();
                        }
                    }
                }
            }
            else
            {
                //  Tells user to choose a folder path for the outputted files
                MessageBox.Show("Error saving files.\n Please select a destination folder.", "Path not selected");

            }


        }

        private void btnFolderPathBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectedPath = new System.Windows.Forms.FolderBrowserDialog();
            if (DialogResult.OK == selectedPath.ShowDialog())
            {
                folderPath = Convert.ToString(selectedPath.SelectedPath);
                lblFileFolderPath.Text = "Folder Path: " + folderPath;
            }
        }


        private void txtFileNameEntry_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_UpdateFile_Enter();
            }
        }

    }
}
