CREATE TABLE auth_user (
    Id CHAR(36) BINARY NOT NULL, 
    Username VARCHAR(255) NOT NULL, 
    NormalizedUsername VARCHAR(255) NOT NULL, 
    PRIMARY KEY (Id), 
    UNIQUE INDEX Id_UNIQUE (Id ASC) VISIBLE
);

INSERT INTO auth_user(Id, Username, NormalizedUsername) VALUES
('647b80f0-8f62-4700-a047-7c9f708a6931','Miky','miky'),
('1abff9ba-b1b3-4477-8303-0408c0fb8301','Bob','bob'),
('2aee661c-bb27-4c0b-829d-7e1084e075ae','Charlie','charlie'),
('247b1e56-4f34-48b9-89b5-20d2608ddf90','Sera','sera');
