using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PreviewObject : MonoBehaviour
{
	int molecul = 0;
	List<KeyValuePair<string, Atome>> atomes= Molecul.atomes;
	Transform target;
	List<Molecul> moleculs = new List<Molecul>
	{
		new Molecul( "Dioxygène","O$1@0&0&0,O$2@2&0&0","O$1-O$2"),
		new Molecul( "Dioxyde de carbone","O$1@0&0&0,C$1@2&0&0,O$2@4&0&0","O$1-C$1,C$1-O$2"),
		new Molecul( "Eau","H$1@0&0&0,O$1@1&1&0,H$2@2&0&0","H$1-O$1,H$2-O$1"),
		new Molecul( "Paracétamol","H$1@0&0&0,O$1@2&1&0,C$1@3&2&0,C$2@5&1&0,H$2@5&-1&0,C$3@7&2&0,H$3@8&0&0,C$4@3&4&0,H$4@1&5&0,C$5@5&5&0,H$5@5&7&0,C$6@7&4&0,N$1@9&5&0,H$6@9&7&0,C$7@11&5&0,O$2@11&3&0,C$8@13&5&0,H$7@15&7&0,H$8@15&5&0,H$9@15&3&0","H$1-O$1,O$1-C$1,C$1-C$2,C$1-C$4,C$4-C$5,C$5-C$6,C$6-C$3,C$3-C$2,C$6-N$1,C$4-H$4,C$3-H$3,C$2-H$2,C$5-H$5,N$1-H$6,C$7-N$1,O$2-C$7,C$7-C$8,C$8-H$7,C$8-H$8,C$8-H$9"),		
		new Molecul( "Vanilin","H$1@0&2&0,H$2@0&0&0,H$3@0&-2&0,C$1@2&0&0,O$1@4&0&0,C$2@5&2&0,C$3@7&2&0,H$4@8&0&0,C$4@4&4&0,O$2@2&4&0,H$5@0&6&0,C$7@5&6&0,H$7@4&8&0,C$8@7&6&0,H$8@8&8&0,C$5@8&4&0,C$6@10&4&0,O$3@10&6&0,H$6@12&4&0","H$1-C$1,H$2-C$1,H$3-C$1,C$1-O$1,C$2-O$1,C$2-C$3,C$2-C$4,O$2-C$4,H$5-O$2,C$4-C$7,C$7-H$7,C$8-C$7,C$8-H$8,H$6-C$6,C$6-O$3,C$6-C$5,C$5-C$3,C$5-C$8,C$3-H$4"),
		new Molecul( "Vitamine C (ou acide ascorbique)","H$1@0&0&0,O$1@0&2&0,C$1@2&4&0,C$2@4&4&0,O$2@6&2&0,C$3@2&6&0,O$3@0&6&0,H$2@-2&6&0,C$4@3&8&0,O$4@4&6&0,O$5@5&8&0,H$3@7&8&0,C$5@3&10&0,O$6@1&10&0,H$4@-1&10&1,H$5@5&10&0,C$6@3&12&0,H$6@1&12&1,H$7@5&12&0,O$7@3&14&0,H$8@0&14&0","H$1-O$1,O$1-C$1,C$1-C$2,C$2-O$2,C$1-C$3,C$3-O$3,O$3-H$2,C$3-C$4,C$4-O$4,O$4-C$2,C$4-O$5,O$5-H$3,C$4-C$5,O$6-C$5,O$6-H$4,C$5-H$5,C$6-C$5,C$6-H$6,C$6-H$7,O$7-H$8,C$6-O$7"),
		new Molecul( "Acide chlorhydrique","H@0&0&0,CI@2&2&2","H-CI"),
		new Molecul( "Méthane","C@0&0&0,H$1@0&-2&0,H$2@-2&2&0,H$3@0&2&0,H$4@2&2&0","H$1-C,C-H$2,C-H$3,C-H$4"),
		new Molecul( "Ibuprofène",
		"C$1@0&0&0,H$1@-2&-2&0,H$2@0&-2&0,H$3@2&-2&0,C$2@0&2&0,H$4@2&2&0,C$3@-2&4&0,H$5@-4&4&-2,H$6@-4&4&2,C$4@2&4&0,H$7@4&4&-2,H$8@4&4&0,H$9@4&4&2,C$5@-2&6&0,C$6@-4&8&0,H$10@-6&8&0,C$7@0&8&0,H$11@2&8&0,C$8@-4&10&0,H$12@-6&10&0,C$9@0&10&0,H$13@2&10&0,C$10@-2&12&0,C$11@-2&14&0,H$14@0&14&0,C$12@-4&16&0,H$15@-6&16&-2,H$16@-6&16&0,H$17@-6&16&2,C$13@0&16&0,O$1@2&14&0,O$2@0&18&0,H$18@2&18&0",
		"C$1-H$1,C$1-H$2,C$1-H$3,C$1-C$2,C$2-H$4,C$2-C$3,C$3-H$5,C$3-H$6,C$2-C$4,C$4-H$7,C$4-H$8,C$4-H$9,C$3-C$5,C$5-C$6,C$6-H$10,C$5-C$7,C$6-C$8,C$7-H$11,C$7-C$9,C$8-C$9,C$8-C$10,C$8-H$12,C$9-C$8,C$9-H$13,C$10-C$11,C$10-C$9,C$10-C$9,C$11-H$14,C$11-C$12,C$12-H$15,C$12-H$16,C$12-H$17,H$14-C$13,C$13-O$1,C$13-O$1,C$13-O$2,O$2-H$18"),

	};

    bool mIsTouching = false;


	List<Node> nodes = new List<Node>();
	List<Edge> edges = new List<Edge>();

	class Edge{
		public Node Node1 { get; }
   		public Node Node2 { get; }

		public Edge(Node node1, Node node2){
			Node1 = node1;
			Node2 = node2;
		}
	}

    // Start is called before the first frame update
    void Start()
    {   
		this.showMolecule(8);
        Camera.main.fieldOfView = GUI.HorizontalSlider(new Rect(20, 20, 100, 40), 100.0f, 150, 20);
    }
	class Node{
   		public string Name { get; }
   		public Atome Atome { get; }
   		public Vector3 Position { get; set; }
		public int moved { get; set; }
		public GameObject Gobj { get; }

	    public Node(string name, Atome atome,GameObject sphere,Vector3 v){
			Name = name;
			Atome = atome;
			Gobj = sphere;
			Position = v;
		}
		public void move(Vector3 pos){
			Position = pos;
			// Gobj.transform.position = Position;
			moved++;
		}
	}
	void showMolecule(int id){
		//create a sphere
		print("show molecule");
		//find molecule in list
		Vector3 origin,target;
		string[] nodes_str = moleculs[id].Formule.Split(',');

		foreach(string nodeposition_str in nodes_str ){
			string[] node_position_separation = nodeposition_str.Split('@');
			string node_id_str = node_position_separation[0];
			string node_str  = node_id_str.Split('$')[0];
			Atome atome1= atomes.Find(item => item.Key == node_str).Value;
			string x  = node_position_separation[1].Split('&')[0];
			string y  = node_position_separation[1].Split('&')[1];
			string z  = node_position_separation[1].Split('&')[2];
			Vector3 v = new Vector3(float.Parse(x),float.Parse(y),float.Parse(z));
			CreateNode(node_id_str,atome1,v);
		}
		string[] edges_list_str = moleculs[id].Structure.Split(',');
		foreach(string edge_str in edges_list_str ){
			string[] a_to_a = edge_str.Split('-');//separer les nodes
			Node node1= nodes.Find(item => item.Name == a_to_a[0]);
			Node node2= nodes.Find(item => item.Name == a_to_a[1]);
			CreateEdge(node1,node2);
		}
	}
	void CreateNode(string name,Atome atome,Vector3 v){
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		 sphere.transform.SetParent(transform);
		sphere.transform.position = v;
		var sphereRenderer = sphere.GetComponent<Renderer>();
		sphereRenderer.material.SetColor("_Color", atome.Color);
		nodes.Add(new Node(name,atome,sphere,v));
		target = sphere.transform;
	}
    float distx,degx;
    float disty,degy;
    float distz,degz;
	void CreateEdge(Node origin,Node target){
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		cylinder.transform.SetParent(transform);
		float h = Vector3.Distance(origin.Position,target.Position)/2;
		cylinder.transform.localScale =new  Vector3(0.3f,h,0.3f);
        cylinder.transform.position = (origin.Position + target.Position)/2.0F;

		distx = origin.Position.x-target.Position.x;
		disty = origin.Position.y-target.Position.y;
		distz = origin.Position.z-target.Position.z;

		degz = (Mathf.Atan(disty/distx)*Mathf.Rad2Deg)+90;
		degy = Mathf.Atan(distz/distx)*Mathf.Rad2Deg;
		if(System.Single.IsNaN( degy )) degy = 0; 
		cylinder.transform.Rotate( 0 ,-degy , degz );
	}

	void CreateEdge2(Vector3 origin,Vector3 target){
		GameObject myLine = new GameObject();
		// myLine.transform.position = origin;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Sprites/Default"));
		lr.SetColors(Color.cyan, Color.cyan);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, origin);
		lr.SetPosition(1,target);
	}
	Vector3  GeneratePosition(){
		System.Random rnd = new System.Random();
		int x  = rnd.Next(5);  // creates a number between 1 and 12
		int y   = rnd.Next(5);   // creates a number between 1 and 6
		int z   = rnd.Next(5);     // creates a number between 0 and 51
		return new Vector3(x,y,z);
	}

	Vector3 mPrevPos = Vector3.zero;
	Vector3 mPosDelta = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
    	mPosDelta = Input.mousePosition - mPrevPos;

		if(Input.GetMouseButton(0)){
			if(Vector3.Dot(transform.up, Vector3.up) >= 0)
    		{
    			transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
    		}else
    		{
    			transform.Rotate(transform.up, Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);	
    		}
				transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
			}
        mPrevPos = Input.mousePosition;
    }
}
