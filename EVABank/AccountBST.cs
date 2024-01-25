public class AccountBST
{
    private class Node
    {
        public Account Data;
        public Node Left;
        public Node Right;

        public Node(Account data)
        {
            Data = data;
        }
    }

    private Node root;

    public void Insert(Account account)
    {
        root = Insert(root, account);
    }

    private Node Insert(Node node, Account account)
    {
        if (node == null)
            return new Node(account);

        if (account.AccountNumber < node.Data.AccountNumber)
            node.Left = Insert(node.Left, account);
        else if (account.AccountNumber > node.Data.AccountNumber)
            node.Right = Insert(node.Right, account);

        return node;
    }

    // Additional methods for the BST (like search, delete, etc.)
}
