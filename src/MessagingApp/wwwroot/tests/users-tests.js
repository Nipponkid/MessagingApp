const assert = require('assert');

import { User } from '../users/users.js';

describe('A User', function () {
    it('has an email address', function () {
        const user = new User('user0@example.com');
        assert.strictEqual(user.email, 'user0@example.com');
    });
});