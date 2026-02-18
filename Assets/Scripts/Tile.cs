using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int X;
    public int Y;

    private Item.Item _item;

    public Item.Item Item
    {
        get => _item;
        set
        {
            if (_item == value) return;
            _item = value;
            Icon.sprite = _item.Sprite;
        }
    }

    public Image Icon;
    public Button ButtonTile;

    public Tile Left => X > 0 ? Board.Instance.Tiles[X - 1, Y] : null;
    public Tile Top => Y > 0 ? Board.Instance.Tiles[X, Y - 1] : null;
    public Tile Rigth => X < Board.Instance.Width - 1 ? Board.Instance.Tiles[X + 1, Y] : null;
    public Tile Bottom => Y < Board.Instance.Height - 1 ? Board.Instance.Tiles[X, Y + 1] : null;

    public Tile[] Neighbours => new[]
    {
        Left,
        Rigth,
        Top,
        Bottom
    };

    private void Start()
    {
        ButtonTile.onClick.AddListener(() => Board.Instance.Select(this));
    }

    public List<Tile> GetConnectedTiles(List<Tile> exclusive = null)
    {
        var result = new List<Tile> { this };
        if (exclusive == null)
        {
            exclusive = new List<Tile> { this };
        }
        else
        {
            exclusive.Add(this);
        }

        foreach (var neighbours in Neighbours)
        {
            if (neighbours == null || exclusive.Contains(neighbours) || neighbours.Item != Item)
            {
                continue;
            }

            result.AddRange(neighbours.GetConnectedTiles(exclusive));
        }

        return result;
    }
}